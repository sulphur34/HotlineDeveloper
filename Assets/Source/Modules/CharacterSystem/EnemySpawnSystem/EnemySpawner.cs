using System;
using Modules.Characters.Enemies.EnemyBehavior;
using Modules.CharacterSystem;
using Modules.DamageReceiverSystem;
using Modules.CharacterSystem.EnemySystem.EnemyBehavior;
using UnityEngine;
using VContainer;

namespace Modules.EnemySpawnSystem
{
    public class EnemySpawner : MonoBehaviour
    {
        private BehaviorConfigFactory _behaviorConfigFactory;
        private IObjectResolver _objectResolver;
        private DamageableConfigFactory _damageableConfigFactory;
        private LevelEnemySpawnConfigs _levelEnemySpawnConfigs;
        private Player _player;
        private WeaponTracker _weaponTracker;

        public event Action<GameObject> Spawned;
        
        [Inject]
        public void Construct(
            LevelEnemySpawnConfigs levelEnemySpawnConfigs,
            BehaviorConfigFactory behaviorConfigFactory, 
            Player player, 
            WeaponTracker weaponTracker, 
            DamageableConfigFactory damageableConfigFactory)
        {
            _behaviorConfigFactory = behaviorConfigFactory;
            _damageableConfigFactory = damageableConfigFactory;
            _levelEnemySpawnConfigs = levelEnemySpawnConfigs;
            _player = player;
            _weaponTracker = weaponTracker;
        }

        public void BuildEnemies()
        {
            foreach (EnemySpawnConfig enemySpawnConfig in _levelEnemySpawnConfigs.EnemySpawnConfigs)
            {
                BuildEnemy(enemySpawnConfig, _player, _weaponTracker);
            }
        }

        private void BuildEnemy(EnemySpawnConfig enemySpawnConfig, Player player, WeaponTracker weaponTracker)
        {
            GameObject instance = Instantiate(enemySpawnConfig.Prefab.gameObject, enemySpawnConfig.SpawnPoint.position, Quaternion.identity);
            BehaviorConfig behaviorConfig = _behaviorConfigFactory.GetBehavior(enemySpawnConfig.Behavior);
            DamageableConfig damageableConfig = _damageableConfigFactory.GetConfig(enemySpawnConfig.DamageableType);
            BehaviorSetup behaviorSetup = instance.GetComponent<BehaviorSetup>();
            behaviorSetup.Initialize(behaviorConfig, enemySpawnConfig.PatrolRoute, weaponTracker, player);
            instance.GetComponent<DamageReceiverSetup>().Initialize(damageableConfig);
            Spawned?.Invoke(instance);
        }
    }
}
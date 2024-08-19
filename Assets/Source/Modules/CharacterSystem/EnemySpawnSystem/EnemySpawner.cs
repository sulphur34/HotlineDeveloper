using System;
using Modules.CharacterSystem.EnemySystem.EnemyBehavior;
using Modules.DamageReceiverSystem;
using Modules.DamagerSystem;
using Modules.WeaponItemSystem;
using UnityEngine;
using VContainer;

namespace Modules.CharacterSystem.EnemySpawnSystem
{
    public class EnemySpawner : MonoBehaviour
    {
        private BehaviorConfigFactory _behaviorConfigFactory;
        private IObjectResolver _objectResolver;
        private DamageableConfigFactory _damageableConfigFactory;
        private LevelEnemySpawnConfigs _levelEnemySpawnConfigs;
        private Player _player;
        private WeaponTracker _weaponTracker;
        private WeaponItemInitializer _weaponItemInitializer;

        public event Action<GameObject> Spawned;

        [Inject]
        public void Construct(
            LevelEnemySpawnConfigs levelEnemySpawnConfigs,
            BehaviorConfigFactory behaviorConfigFactory,
            Player player,
            WeaponTracker weaponTracker,
            DamageableConfigFactory damageableConfigFactory,
            WeaponItemInitializer weaponItemInitializer)
        {
            _weaponItemInitializer = weaponItemInitializer;
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
            GameObject instance = Instantiate(
                enemySpawnConfig.Prefab.gameObject,
                enemySpawnConfig.SpawnPoint.position,
                Quaternion.identity);
            SetBehavior(instance, enemySpawnConfig, player, weaponTracker);
            SetDamageReceiver(instance, enemySpawnConfig);
            Spawned?.Invoke(instance);
        }

        private void SetBehavior(
            GameObject instance,
            EnemySpawnConfig enemySpawnConfig,
            Player player,
            WeaponTracker weaponTracker)
        {
            BehaviorSetup behaviorSetup = instance.GetComponent<BehaviorSetup>();
            BehaviorConfig behaviorConfig = _behaviorConfigFactory.GetBehavior(enemySpawnConfig.Behavior);
            behaviorSetup.Initialize(
                behaviorConfig,
                enemySpawnConfig.PatrolRoute,
                weaponTracker,
                player,
                _weaponItemInitializer);
        }

        private void SetDamageReceiver(GameObject instance, EnemySpawnConfig enemySpawnConfig)
        {
            DamageableConfig damageableConfig = _damageableConfigFactory.GetConfig(enemySpawnConfig.DamageableType);
            instance.GetComponent<DamageReceiverSetup>().Initialize(damageableConfig);
        }
    }
}
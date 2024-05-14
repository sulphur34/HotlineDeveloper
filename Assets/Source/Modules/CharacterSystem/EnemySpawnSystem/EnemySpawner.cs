using Modules.Characters.Enemies.EnemyBehavior;
using Modules.CharacterSystem.Player;
using Modules.DamageSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Modules.EnemySpawnSystem
{
    public class EnemySpawner : MonoBehaviour
    {
        private BehaviorConfigFactory _behaviorConfigFactory;
        private IObjectResolver _objectResolver;
        private DamageableConfig _damageableConfig;
        
        [Inject]
        public void Construct(
            LevelEnemySpawnConfigs levelEnemySpawnConfigs,
            BehaviorConfigFactory behaviorConfigFactory, 
            Player player, 
            WeaponTracker weaponTracker, 
            DamageableConfig damageableConfig)
        {
            _behaviorConfigFactory = behaviorConfigFactory;
            _damageableConfig = damageableConfig;
            
            foreach (EnemySpawnConfig enemySpawnConfig in levelEnemySpawnConfigs.EnemySpawnConfigs)
            {
                BuildEnemy(enemySpawnConfig, player, weaponTracker);
            }
        }

        private void BuildEnemy(EnemySpawnConfig enemySpawnConfig, Player player, WeaponTracker weaponTracker)
        {
            GameObject instance = Instantiate(enemySpawnConfig.Prefab.gameObject, enemySpawnConfig.SpawnPoint.position, Quaternion.identity);
            BehaviorConfig behaviorConfig = _behaviorConfigFactory.GetBehavior(enemySpawnConfig.Behavior);
            instance.GetComponent<BehaviorSetup>().Initialize(behaviorConfig, enemySpawnConfig.PatrolRoute, weaponTracker, player);
            instance.GetComponent<DamageReceiverSetup>().Construct(_damageableConfig);
        }
    }
}
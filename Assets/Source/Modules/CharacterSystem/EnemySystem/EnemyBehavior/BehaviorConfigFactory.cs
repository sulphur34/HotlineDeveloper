using Modules.CharacterSystem.EnemySystem.EnemyBehavior;
using UnityEngine;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior
{
    [CreateAssetMenu(fileName = "Behavior Config Factory")]
    public class BehaviorConfigFactory : ScriptableObject
    {
        [SerializeField] internal BehaviorConfig _meleeConfig;
        [SerializeField] internal BehaviorConfig _rangeConfig;
        [SerializeField] internal BehaviorConfig _strongConfig;
        [SerializeField] internal BehaviorConfig _bossConfig;
        [SerializeField] internal BehaviorConfig _peaceConfig;
        [SerializeField] internal BehaviorConfig _fanaticConfig;

        internal BehaviorConfig GetBehavior(Behaviors behavior)
        {
            return behavior switch
            {
                Behaviors.Melee => _meleeConfig,
                Behaviors.Range => _rangeConfig,
                Behaviors.Strong => _strongConfig,
                Behaviors.Boss => _bossConfig,
                Behaviors.Peace => _peaceConfig,
                Behaviors.Fanatic => _fanaticConfig,
                _ => _peaceConfig
            };
        }
    }
}
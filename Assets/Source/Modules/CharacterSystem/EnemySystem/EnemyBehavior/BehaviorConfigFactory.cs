using Modules.CharacterSystem.EnemySystem.EnemyBehavior;
using UnityEngine;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior
{
    [CreateAssetMenu(fileName = "Behavior Config Factory")]
    public class BehaviorConfigFactory : ScriptableObject
    {
        [SerializeField] private BehaviorConfig _meleeConfig;
        [SerializeField] private BehaviorConfig _rangeConfig;
        [SerializeField] private BehaviorConfig _strongConfig;
        [SerializeField] private BehaviorConfig _bossConfig;
        [SerializeField] private BehaviorConfig _peaceConfig;
        [SerializeField] private BehaviorConfig _fanaticConfig;

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
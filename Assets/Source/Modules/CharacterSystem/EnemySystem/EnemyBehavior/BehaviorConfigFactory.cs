using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior
{
    [CreateAssetMenu(fileName = "Behavior Config Factory")]
    public class BehaviorConfigFactory : ScriptableObject
    {
        [SerializeField] private BehaviorConfig _normalConfig;
        [SerializeField] private BehaviorConfig _strongConfig;
        [SerializeField] private BehaviorConfig _bossConfig;

        public BehaviorConfig GetBehavior(Behaviors behavior)
        {
            return behavior switch
            {
                Behaviors.Normal => _normalConfig,
                Behaviors.Strong => _strongConfig,
                Behaviors.Boss => _bossConfig,
                _ => _normalConfig
            };
        }
    }
}
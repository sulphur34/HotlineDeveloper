using Modules.DamageSystem.DamageStrategy;
using UnityEngine;

namespace Source.Modules.DamageSystem
{
    [CreateAssetMenu(fileName = "Damageable Config")]
    public class DamageableConfig : ScriptableObject
    {
        [SerializeField] private DamageReceiveStrategies damageReceiveStrategies;
        [field: SerializeField] public float MaxValue { get; private set; }
        [field: SerializeField] public float RecoverTime { get; private set; }

        public IDamageReceiveStrategy DamageReceiveStrategy => GetDamageStrategy(damageReceiveStrategies);

        private IDamageReceiveStrategy GetDamageStrategy(DamageReceiveStrategies damageReceiveStrategies)
        {
            switch (damageReceiveStrategies)
            {
                case DamageReceiveStrategies.Normal:
                    return new NormalDamageReceiveStrategy();

                case DamageReceiveStrategies.KnockoutImmune:
                    return new KnockoutImmuneReceiveStrategy();

                case DamageReceiveStrategies.MeleeImmune:
                    return new MeleeImmuneReceiveStrategy();

                default:
                    return new NormalDamageReceiveStrategy();
            }
        }
    }
}
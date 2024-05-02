using Modules.DamageSystem.DamageStrategy;
using UnityEngine;

namespace Source.Modules.DamageSystem
{
    [CreateAssetMenu(fileName = "Damageable Config")]
    public class DamageableConfig : ScriptableObject
    {
        [SerializeField] private DamageStrategies _damageStrategies;
        [field: SerializeField] public float MaxValue { get; private set; }
        [field: SerializeField] public float RecoverTime { get; private set; }

        public IDamageStrategy DamageStrategy => GetDamageStrategy(_damageStrategies);

        private IDamageStrategy GetDamageStrategy(DamageStrategies damageStrategies)
        {
            switch (damageStrategies)
            {
                case DamageStrategies.Normal:
                    return new NormalDamageStrategy();

                case DamageStrategies.KnockoutImmune:
                    return new KnockoutImmuneStrategy();

                case DamageStrategies.MeleeImmune:
                    return new MeleeImmuneDamageStrategy();

                default:
                    return new NormalDamageStrategy();
            }
        }
    }
}
using Modules.DamageReceiverSystem.DamageReceiveStrategies;
using UnityEngine;

namespace Modules.DamageReceiverSystem
{
    [CreateAssetMenu(fileName = "Damageable Config")]
    public class DamageableConfig : ScriptableObject
    {
        [SerializeField] private DamageReceiveStrategies.DamageReceiveStrategies _damageReceiveStrategies;

        [field: SerializeField] public float MaxValue { get; private set; }

        [field: SerializeField] public float RecoverTime { get; private set; }

        internal IDamageReceiveStrategy DamageReceiveStrategy => GetDamageStrategy(_damageReceiveStrategies);

        private IDamageReceiveStrategy GetDamageStrategy(DamageReceiveStrategies.DamageReceiveStrategies damageReceiveStrategies)
        {
            switch (damageReceiveStrategies)
            {
                case DamageReceiveStrategies.DamageReceiveStrategies.Normal:
                    return new NormalDamageReceiveStrategy();

                case DamageReceiveStrategies.DamageReceiveStrategies.KnockoutImmune:
                    return new KnockoutImmuneReceiveStrategy();

                case DamageReceiveStrategies.DamageReceiveStrategies.MeleeImmune:
                    return new MeleeImmuneReceiveStrategy();

                case DamageReceiveStrategies.DamageReceiveStrategies.AlwaysLethal:
                    return new AlwaysLethalReceiveStrategy();

                case DamageReceiveStrategies.DamageReceiveStrategies.Immortal:
                    return new ImmortalReceiveStrategy();

                case DamageReceiveStrategies.DamageReceiveStrategies.LethalAsNormal:
                    return new LethalAsNormalReceiveStrategy();

                default:
                    return new NormalDamageReceiveStrategy();
            }
        }
    }
}
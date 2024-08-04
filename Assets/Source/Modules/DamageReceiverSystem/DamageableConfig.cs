using Modules.DamageReceiverSystem.DamageStrategy;
using UnityEngine;

namespace Modules.DamageReceiverSystem
{
    [CreateAssetMenu(fileName = "Damageable Config")]
    public class DamageableConfig : ScriptableObject
    {
        [SerializeField] private DamageReceiveStrategies _damageReceiveStrategies;
        [field: SerializeField] public float MaxValue { get; private set; }
        [field: SerializeField] public float RecoverTime { get; private set; }

        internal IDamageReceiveStrategy DamageReceiveStrategy => GetDamageStrategy(_damageReceiveStrategies);

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
                
                case DamageReceiveStrategies.AlwaysLethal:
                    return new AlwaysLethalReceiveStrategy();
                
                case DamageReceiveStrategies.Immortal:
                    return new ImmortalReceiveStrategy();
                
                case DamageReceiveStrategies.LethalAsNormal:
                    return new LethalAsNormalReceiveStrategy();

                default:
                    return new NormalDamageReceiveStrategy();
            }
        }
    }
}
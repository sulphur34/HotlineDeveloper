using Modules.DamageReceiverSystem;

namespace Modules.DamagerSystem.DamageInflictStrategies
{
    public interface IDamageInflictStrategy
    {
        void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData);
    }
}
namespace Modules.DamagerSystem
{
    public interface IDamageInflictStrategy
    {
        void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData);
    }
}
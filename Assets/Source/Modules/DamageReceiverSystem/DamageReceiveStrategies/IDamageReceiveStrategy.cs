namespace Modules.DamageReceiverSystem.DamageReceiveStrategies
{
    internal interface IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData);
    }
}
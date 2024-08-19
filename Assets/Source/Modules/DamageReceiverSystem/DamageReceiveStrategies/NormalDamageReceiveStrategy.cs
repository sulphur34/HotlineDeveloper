namespace Modules.DamageReceiverSystem.DamageReceiveStrategies
{
    internal class NormalDamageReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            return damageData;
        }
    }
}
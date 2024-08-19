namespace Modules.DamageReceiverSystem.DamageReceiveStrategies
{
    internal class ImmortalReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            return DamageData.ZeroDamage;
        }
    }
}
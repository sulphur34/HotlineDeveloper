namespace Modules.DamageReceiverSystem.DamageReceiveStrategies
{
    internal class AlwaysLethalReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            return DamageData.ExecutionDamage;
        }
    }
}
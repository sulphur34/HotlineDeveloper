namespace Modules.DamageReceiverSystem.DamageReceiveStrategies
{
    internal class LethalAsNormalReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            return damageData.IsLethal ? DamageData.RangeDamage : DamageData.ZeroDamage;
        }
    }
}
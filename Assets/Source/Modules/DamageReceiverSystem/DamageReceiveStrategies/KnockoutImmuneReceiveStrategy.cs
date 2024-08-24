namespace Modules.DamageReceiverSystem.DamageReceiveStrategies
{
    internal class KnockoutImmuneReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            if (damageData.IsKnockout)
                return DamageData.ZeroDamage;

            return damageData;
        }
    }
}
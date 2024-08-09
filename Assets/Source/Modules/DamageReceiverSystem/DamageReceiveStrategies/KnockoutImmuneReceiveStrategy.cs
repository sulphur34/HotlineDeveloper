namespace Modules.DamagerSystem.DamageStrategy
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
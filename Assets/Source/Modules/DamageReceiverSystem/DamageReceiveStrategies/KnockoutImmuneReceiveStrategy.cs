namespace Modules.DamageReceiverSystem.DamageStrategy
{
    public class KnockoutImmuneReceiveStrategy : IDamageReceiveStrategy
    {
        public virtual DamageData GetDamage(DamageData damageData)
        {
            if (damageData.IsKnockout)
                return DamageData.ZeroDamage;

            return damageData;
        }
    }
}
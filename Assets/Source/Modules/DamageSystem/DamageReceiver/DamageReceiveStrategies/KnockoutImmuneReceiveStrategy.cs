using Modules.DamageSystem;

namespace Modules.DamageSystem.DamageStrategy
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
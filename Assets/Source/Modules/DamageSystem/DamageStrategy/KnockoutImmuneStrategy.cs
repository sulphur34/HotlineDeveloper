using Modules.DamageSystem;

namespace Modules.DamageSystem.DamageStrategy
{
    public class KnockoutImmuneStrategy : IDamageStrategy
    {
        public virtual DamageData GetDamage(DamageData damageData)
        {
            if (damageData.IsKnockout)
                return DamageData.ZeroDamage;

            return damageData;
        }
    }
}
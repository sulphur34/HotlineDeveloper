using Modules.DamageSystem;

namespace Modules.DamageSystem.DamageStrategy
{
    public class NormalDamageStrategy : IDamageStrategy
    {
        public virtual DamageData GetDamage(DamageData damageData)
        {
            return damageData;
        }
    }
}
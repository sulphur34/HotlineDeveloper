using Modules.DamageSystem;

namespace Modules.DamageSystem.DamageStrategy
{
    public class NormalDamageReceiveStrategy : IDamageReceiveStrategy
    {
        public virtual DamageData GetDamage(DamageData damageData)
        {
            return damageData;
        }
    }
}
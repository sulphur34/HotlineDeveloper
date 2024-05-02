using Modules.Weapons.WeaponTypeSystem;

namespace Modules.DamageSystem.DamageStrategy
{
    public class MeleeImmuneDamageStrategy : IDamageStrategy
    {
        public virtual DamageData GetDamage(DamageData damageData)
        {
            if (damageData.WeaponType == WeaponType.Melee)
                return DamageData.ZeroDamage;

            return damageData;
        }
    }
}
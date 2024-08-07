using Modules.Weapons.WeaponTypeSystem;
using Modules.WeaponTypes;

namespace Modules.DamageReceiverSystem.DamageStrategy
{
    internal class MeleeImmuneReceiveStrategy : IDamageReceiveStrategy
    {
        public DamageData GetDamage(DamageData damageData)
        {
            if (damageData.WeaponType == WeaponType.Melee)
                return DamageData.ZeroDamage;

            return damageData;
        }
    }
}
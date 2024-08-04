using Modules.Weapons.WeaponTypeSystem;

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
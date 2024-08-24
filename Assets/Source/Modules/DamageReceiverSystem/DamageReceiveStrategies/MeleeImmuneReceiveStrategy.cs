using Modules.WeaponsTypes;

namespace Modules.DamageReceiverSystem.DamageReceiveStrategies
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
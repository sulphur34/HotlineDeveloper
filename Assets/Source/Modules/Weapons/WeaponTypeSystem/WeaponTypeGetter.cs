using Modules.Weapons.Melee;
using Modules.Weapons.Range;
using System;
using Modules.WeaponTypes;

namespace Modules.Weapons.WeaponTypeSystem
{
    internal class WeaponTypeGetter
    {
        internal WeaponType Get(IAttackModule attackModule)
        {
            switch (attackModule)
            {
                case RangeAttackModule:
                    return WeaponType.Range;
                case MeleeAttackModule:
                    return WeaponType.Melee;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
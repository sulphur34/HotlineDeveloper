using System;
using UnityEngine;

namespace Modules.Weapons.Range
{
    [CreateAssetMenu(fileName = "Range Weapon Config Fabric")]
    public class RangeWeaponConfigFactory : ScriptableObject
    {
        [field: SerializeField] internal RangeWeaponConfig Pistol { get; private set; }
        [field: SerializeField] internal RangeWeaponConfig Revolver { get; private set; }
        [field: SerializeField] internal RangeWeaponConfig SawedOffShotgun { get; private set; }
        [field: SerializeField] internal RangeWeaponConfig Shotgun { get; private set; }
        [field: SerializeField] internal RangeWeaponConfig AssaultRifle { get; private set; }
        [field: SerializeField] internal RangeWeaponConfig SubmachineGun { get; private set; }

        internal RangeWeaponConfig Get(ShotStrategy shotStrategy)
        {
            switch (shotStrategy)
            {
                case RevolverStrategy:
                    return Revolver;
                case AssaultRifleStrategy:
                    return AssaultRifle;
                case SubmachineGunStrategy:
                    return SubmachineGun;
                case SawedOffShotgunStrategy:
                    return SawedOffShotgun;
                case PistolStrategy:
                    return Pistol;
                case ShotgunStrategy:
                    return Shotgun;
               default:
                    throw new ArgumentException();
            }
        }
    }
}
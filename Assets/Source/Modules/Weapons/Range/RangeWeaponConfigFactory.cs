using System;
using UnityEngine;

namespace Modules.Weapons.Range
{
    [CreateAssetMenu(fileName = "Range Weapon Config Fabric")]
    public class RangeWeaponConfigFactory : ScriptableObject
    {
        [field: SerializeField] internal RangeWeaponConfig Pistol { get; private set; }
        
        [field: SerializeField] internal RangeWeaponConfig NoHarmPistol { get; private set; }
        [field: SerializeField] internal RangeWeaponConfig Shotgun { get; private set; }
        
        [field: SerializeField] internal RangeWeaponConfig AssaultRifle { get; private set; }
        
        [field: SerializeField] internal RangeWeaponConfig SubmachineGun { get; private set; }

        internal RangeWeaponConfig Get(ShotStrategy shotStrategy)
        {
            switch (shotStrategy)
            {
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
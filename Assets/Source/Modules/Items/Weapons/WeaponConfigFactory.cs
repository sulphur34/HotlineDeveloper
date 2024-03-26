using System;
using UnityEngine;

namespace Modules.Items.Weapons
{
    [CreateAssetMenu(fileName = "Weapon Config Fabric")]
    public class WeaponConfigFactory : ScriptableObject
    {
        [field: SerializeField] internal WeaponConfig Pistol { get; private set; }
        [field: SerializeField] internal WeaponConfig Shotgun { get; private set; }

        internal WeaponConfig Get(ShotStrategy shotStrategy)
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
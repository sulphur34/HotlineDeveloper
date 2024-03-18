using System;
using UnityEngine;

namespace Modules.Items.Weapons
{
    [CreateAssetMenu(fileName = "Weapon Config Fabric")]
    public class WeaponConfigFabric : ScriptableObject
    {
        [field: SerializeField] internal WeaponConfig Pistol { get; private set; }
        [field: SerializeField] internal WeaponConfig Shotgun { get; private set; }

        internal WeaponConfig Get(Weapon weapon)
        {
            switch (weapon)
            {
                case Weapon:
                    return Pistol;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
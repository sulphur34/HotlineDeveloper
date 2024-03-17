using System;
using UnityEngine;

namespace Modules.Items.Weapons
{
    [CreateAssetMenu(fileName = "Bullet Config Fabric")]
    public class BulletConfigFabric : ScriptableObject
    {
        [field: SerializeField] internal BulletConfig Pistol { get; private set; }
        [field: SerializeField] internal BulletConfig Shotgun { get; private set; }

        internal BulletConfig Get(Weapon weapon)
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
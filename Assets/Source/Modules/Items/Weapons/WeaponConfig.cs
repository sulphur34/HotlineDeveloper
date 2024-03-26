using Modules.BulletSystem;
using UnityEngine;

namespace Modules.Items.Weapons
{
    [CreateAssetMenu(fileName = "Weapon Config")]
    internal class WeaponConfig : ScriptableObject
    {
        [field: SerializeField] internal Bullet BulletPrefab { get; private set; }
        [field: SerializeField] internal uint BulletsCount { get; private set; }
        [field: SerializeField] internal float BulletSpeed { get; private set; }
        [field: SerializeField] internal float RechargeTime { get; private set; }
    }
}
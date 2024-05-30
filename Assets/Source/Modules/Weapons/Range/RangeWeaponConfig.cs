using Modules.BulletSystem;
using UnityEngine;

namespace Modules.Weapons.Range
{
    [CreateAssetMenu(fileName = "Range Weapon Config", menuName = "Data/Range Weapon Config")]
    internal class RangeWeaponConfig : ScriptableObject
    {
        [field: SerializeField] internal Bullet BulletPrefab { get; private set; }
        [field: SerializeField] internal uint BulletsCount { get; private set; }
        [field: SerializeField] internal float BulletSpeed { get; private set; }
        [field: SerializeField] internal float RechargeTime { get; private set; }
    }
}
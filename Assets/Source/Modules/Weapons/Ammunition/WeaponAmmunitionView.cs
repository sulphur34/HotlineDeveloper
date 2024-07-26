using System;
using UnityEngine;

namespace Modules.Weapons.Ammunition
{
    public class WeaponAmmunitionView : MonoBehaviour, IAmmunitionView
    {
        [field: SerializeField] public Sprite AmmoIcon { get; private set; }
        
        public uint CurrentAmmoCount { get; private set; }
        public event Action<uint> Changed;

        public void UpdateCount(uint count)
        {
            CurrentAmmoCount = count;
            Changed?.Invoke(count);
        }
    }
}
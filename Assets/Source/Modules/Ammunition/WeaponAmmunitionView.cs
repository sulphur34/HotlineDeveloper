using System;
using UnityEngine;

namespace Modules.Ammunition
{
    public class WeaponAmmunitionView : MonoBehaviour, IAmmunitionView
    {
        [field: SerializeField] public Sprite AmmoIcon { get; private set; }

        public event Action<uint> Changed;

        public uint CurrentAmmoCount { get; private set; }

        public void UpdateCount(uint count)
        {
            CurrentAmmoCount = count;
            Changed?.Invoke(count);
        }
    }
}
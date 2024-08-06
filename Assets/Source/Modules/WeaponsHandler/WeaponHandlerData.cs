using System;
using Modules.Weapons.WeaponItemSystem;
using UnityEngine;

namespace Modules.PlayerWeaponsHandler
{
    [Serializable]
    public class WeaponHandlerData
    {
        [field: SerializeField] public WeaponItem DefaultWeapon { get; private set; }
        [field: SerializeField] public Transform Container { get; private set; }
        [field: SerializeField] public Transform PickPoint { get; private set; }
        [field: SerializeField] public float PickRadius { get; private set; }
        [field: SerializeField] public float LookHeight { get; private set; } = 1.5f;
    }
}
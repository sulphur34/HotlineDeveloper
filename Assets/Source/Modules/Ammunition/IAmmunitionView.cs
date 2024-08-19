using System;
using UnityEngine;

namespace Modules.Weapons.Ammunition
{
    public interface IAmmunitionView
    {
        event Action<uint> Changed;

        Sprite AmmoIcon { get; }

        uint CurrentAmmoCount { get; }
    }
}
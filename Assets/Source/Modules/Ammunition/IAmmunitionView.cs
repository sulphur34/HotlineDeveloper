using System;
using UnityEngine;

namespace Modules.Ammunition
{
    public interface IAmmunitionView
    {
        event Action<uint> Changed;

        Sprite AmmoIcon { get; }

        uint CurrentAmmoCount { get; }
    }
}
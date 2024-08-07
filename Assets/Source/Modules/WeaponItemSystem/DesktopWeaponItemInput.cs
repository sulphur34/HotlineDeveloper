using System;
using UnityEngine;
using VContainer.Unity;

namespace Modules.Weapons.WeaponItemSystem
{
    public class DesktopWeaponItemInput : IWeaponItemInput, ITickable
    {
        public event Action Received;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(1))
                Received?.Invoke();
        }
    }
}
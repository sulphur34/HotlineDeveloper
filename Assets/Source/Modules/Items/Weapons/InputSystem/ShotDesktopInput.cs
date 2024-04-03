using System;
using UnityEngine;
using VContainer.Unity;

namespace Modules.Items.Weapons.InputSystem
{
    public class ShotDesktopInput : IShotInput, ITickable
    {
        public event Action Received;

        public void Tick()
        {
            if (Input.GetMouseButton(0))
                Received?.Invoke();
        }
    }
}
using System;
using UnityEngine;
using VContainer.Unity;

namespace Modules.Items.Weapons
{
    public class ShotDesktopInput : IShotInput, ITickable
    {
        public event Action Received;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
                Received?.Invoke();
        }
    }
}
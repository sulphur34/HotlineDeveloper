using System;
using Source.Modules.InputSystem;
using UnityEngine;
using VContainer.Unity;

namespace Modules.DamageSystem
{
    public class TestAttackController : IAttackInput, IFinishOffInput, ITickable
    {
        public event Action AttackReceived;

        public event Action FinishOffReceived;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
                AttackReceived?.Invoke();
            
            if (Input.GetKey(KeyCode.Space))
                FinishOffReceived?.Invoke();
        }
    }
}
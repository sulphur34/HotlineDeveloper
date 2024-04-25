using System;
using Source.Modules.InputSystem.Interfaces;
using UnityEngine;

namespace Source.Modules.InputSystem
{
    public class AiInput : MonoBehaviour, IAttackInput, IPickInput
    {
        public event Action AttackReceived;
        public event Action PickReceived;
        
        public void ReceiveAttack()
        {
            AttackReceived?.Invoke();
        }

        public void RecievePick()
        {
            PickReceived?.Invoke();
        }
    }
}
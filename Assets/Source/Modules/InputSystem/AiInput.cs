using System;
using Modules.DamageSystem;
using Source.Modules.InputSystem.Interfaces;
using UnityEngine;

namespace Source.Modules.InputSystem
{
    public class AiInput : MonoBehaviour, IAttackInput, IPickInput
    {
        public event Action AttackReceived;
        public event Action PickRecieved;
        
        public void ReceiveAttack()
        {
            AttackReceived?.Invoke();
        }

        public void RecievePick()
        {
            PickRecieved?.Invoke();
        }
    }
}
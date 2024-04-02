using System;
using System.Numerics;
using Modules.DamageSystem;
using Modules.MoveSystem;
using Source.Modules.InputSystem.Interfaces;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

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
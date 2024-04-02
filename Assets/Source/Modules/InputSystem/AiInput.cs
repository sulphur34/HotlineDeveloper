using System;
using System.Numerics;
using Modules.DamageSystem;
using Modules.MoveSystem;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Source.Modules.InputSystem
{
    public class AiInput : MonoBehaviour, IAttackInput
    {
        public event Action AttackReceived;
        
        public void ReceiveAttack()
        {
            AttackReceived?.Invoke();
        }

    }
}
using System;
using Modules.InputSystem.Interfaces;

namespace Modules.InputSystem
{
    public class AiInput : IAttackInput, IPickInput
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
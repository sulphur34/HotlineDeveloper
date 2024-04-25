using System;

namespace Source.Modules.InputSystem.Interfaces
{
    public interface  IAttackInput
    {
        event Action AttackReceived;
    }
}
using System;

namespace Modules.InputSystem.Interfaces
{
    public interface IAttackInput
    {
        event Action AttackReceived;
    }
}
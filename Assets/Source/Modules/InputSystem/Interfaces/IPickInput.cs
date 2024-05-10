using System;

namespace Modules.InputSystem.Interfaces
{
    public interface IPickInput
    {
        event Action PickReceived;
    }
}
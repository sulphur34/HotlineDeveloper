using System;

namespace Modules.Weapons.InputSystem
{
    public interface IShotInput
    {
        event Action Received;
    }
}
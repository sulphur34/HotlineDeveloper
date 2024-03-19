using System;

namespace Modules.Items.Weapons.InputSystem
{
    public interface IShotInput
    {
        event Action Received;
    }
}
using System;

namespace Modules.Items.Weapons
{
    internal interface IShotInput
    {
        event Action Received;
    }
}
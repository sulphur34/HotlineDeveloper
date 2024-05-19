using System;
using UnityEngine;

namespace Modules.InputSystem.Interfaces
{
    public interface IMoveInput
    {
        event Action<Vector2> MoveReceived;
    }
}
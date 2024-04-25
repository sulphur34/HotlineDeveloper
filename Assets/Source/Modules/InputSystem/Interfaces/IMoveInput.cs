using System;
using UnityEngine;

namespace Source.Modules.InputSystem.Interfaces
{
    public interface IMoveInput
    {
        event Action<Vector2> MoveReceived;
    }
}
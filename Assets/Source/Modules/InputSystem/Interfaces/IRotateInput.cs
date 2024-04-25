using System;
using UnityEngine;

namespace Source.Modules.InputSystem.Interfaces
{
    public interface IRotateInput
    {
        event Action<Vector2> RotationReceived;
    }
}
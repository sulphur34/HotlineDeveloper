using System;
using UnityEngine;

namespace Modules.InputSystem.Interfaces
{
    public interface IRotateInput
    {
        event Action<Vector2> RotationReceived;
    }
}
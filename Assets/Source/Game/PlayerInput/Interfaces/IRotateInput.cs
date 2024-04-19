using System;
using UnityEngine;

namespace Modules.MoveSystem
{
    public interface IRotateInput
    {
        event Action<Vector2> RotationReceived;
    }
}
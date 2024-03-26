using System;

namespace Modules.MoveSystem
{
    public interface IRotateInput
    {
        event Action<float> RotationReceived;
    }
}
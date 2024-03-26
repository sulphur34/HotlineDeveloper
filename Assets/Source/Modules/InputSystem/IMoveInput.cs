using System;
using UnityEngine;

namespace Modules.MoveSystem
{
    public interface IMoveInput
    {
        event Action<Vector2> MoveReceived;
    }
}


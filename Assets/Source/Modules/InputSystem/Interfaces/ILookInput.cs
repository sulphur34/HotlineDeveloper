using System;
using UnityEngine;

namespace Modules.InputSystem.Interfaces
{
    public interface ILookInput
    {
        public event Action<Vector2> LookReceived;
    }
}
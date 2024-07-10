using System;
using UnityEngine;

namespace Modules.InputSystem.Interfaces
{
    public interface IFarLookInput
    {
        public event Action<Vector2> FarLookReceived;
    }
}
using System;
using Modules.MoveSystem;
using UnityEngine;
using VContainer.Unity;

namespace Modules.MoveSystem
{
    public class TestMoveController : IMoveInput, IRotateInput, IFixedTickable
    {
        public event Action<Vector2> MoveReceived;
        public event Action<float> RotationReceived;

        public void FixedTick()
        {
            if (Input.GetKey(KeyCode.W))
                MoveReceived?.Invoke(Vector2.up);
            
            if (Input.GetKey(KeyCode.A))
                MoveReceived?.Invoke(Vector2.left);
            
            if (Input.GetKey(KeyCode.D))
                MoveReceived?.Invoke(Vector2.right);
            
            if (Input.GetKey(KeyCode.S))
                MoveReceived?.Invoke(Vector2.down);

            float mouseX = Input.GetAxis("Mouse X");
            
            RotationReceived?.Invoke(mouseX);
        }
    }
}
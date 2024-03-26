using UnityEngine;

namespace Modules.MoveSystem
{
    public interface IMovable
    {
        public void RotateHorizontal(float rotationValue);
        public void MoveHorizontal(Vector2 direction);
    }
}
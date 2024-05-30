using UnityEngine;

namespace Modules.MoveSystem
{
    public interface IMovable
    {
        public void RotateHorizontal(Vector2 rotationValue);
        public void MoveHorizontal(Vector2 direction);
    }
}
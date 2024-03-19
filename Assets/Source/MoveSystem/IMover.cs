using UnityEngine;

namespace Source.Scripts.Character
{
    public interface IMover
    {
        public void Move(Vector3 direction);
        public void Rotate(Vector3 direction);
        public void RotateHorizontal(float rotationValue);
        public void MoveHorizontal(Vector2 direction);
    }
}
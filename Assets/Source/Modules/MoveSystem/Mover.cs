using UnityEngine;

namespace Modules.MoveSystem
{
    public class Mover : IMovable
    {
        private CharacterController _characterController;
        private Transform _transform;
        private float _moveMoveSpeed;
        private float _rotationSpeed;


        public Mover(CharacterController characterController, Transform transform, MoverConfig config)
        {
            _characterController = characterController;
            _transform = transform;
            _moveMoveSpeed = config.MoveSpeed;
            _rotationSpeed = config.RotationSpeed;
        }

        public void RotateHorizontal(float rotationValue)
        {
            _transform.Rotate(new Vector3(0f, rotationValue * _rotationSpeed, 0f));
        }

        public void MoveHorizontal(Vector2 direction)
        {
            _characterController.Move(new Vector3(direction.x, 0f, direction.y));
        }
    }
}
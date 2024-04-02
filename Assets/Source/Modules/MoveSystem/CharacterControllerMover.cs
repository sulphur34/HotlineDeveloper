using UnityEngine;

namespace Modules.MoveSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerMover : IMovable
    {
        private CharacterController _characterController;
        private Transform _transform;
        private float _moveMoveSpeed;
        private float _rotationSpeed;


        public CharacterControllerMover(CharacterController characterController, MoverConfig config)
        {
            _characterController = characterController;
            _moveMoveSpeed = config.MoveSpeed;
            _rotationSpeed = config.RotationSpeed;
        }

        public void RotateHorizontal(float rotationValue)
        {
            
        }

        public void MoveHorizontal(Vector2 direction)
        {
            _characterController.Move(direction);
        }
    }
}
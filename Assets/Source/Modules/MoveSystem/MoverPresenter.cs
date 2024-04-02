using UnityEngine;

namespace Modules.MoveSystem
{
    internal class MoverPresenter
    {
        private readonly RigidbodyMover _rigidbodyMover;
        private IMoveInput _moveInput;
        private IRotateInput _rotateInput;

        public MoverPresenter(RigidbodyMover rigidbodyMover, IMoveInput moveInput, IRotateInput rotateInput)
        {
            _rigidbodyMover = rigidbodyMover;
            _moveInput = moveInput;
            _moveInput.MoveReceived += OnMove;
            _rotateInput = rotateInput;
            _rotateInput.RotationReceived += OnRotate;
        }

        public void Dispose()
        {
            _moveInput.MoveReceived -= OnMove;
            _rotateInput.RotationReceived -= OnRotate;
        }

        private void OnMove(Vector2 direction)
        {
            _rigidbodyMover.MoveHorizontal(direction);
        }

        private void OnRotate(float rotationValue)
        {
            _rigidbodyMover.RotateHorizontal(rotationValue);
        }
    }
}
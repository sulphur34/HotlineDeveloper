using Source.Modules.InputSystem.Interfaces;
using UnityEngine;

namespace Modules.MoveSystem
{
    internal class MoverPresenter
    {
        private readonly Mover _mover;
        private IMoveInput _moveInput;
        private IRotateInput _rotateInput;

        public MoverPresenter(Mover mover, IMoveInput moveInput, IRotateInput rotateInput)
        {
            _mover = mover;
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
            _mover.MoveHorizontal(direction);
        }

        private void OnRotate(Vector2 direction)
        {
            _mover.RotateHorizontal(direction);
        }
    }
}
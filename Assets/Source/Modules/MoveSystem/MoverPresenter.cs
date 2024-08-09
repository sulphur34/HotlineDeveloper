using System;
using Modules.InputSystem.Interfaces;
using UnityEngine;

namespace Modules.MoveSystem
{
    internal class MoverPresenter : IDisposable
    {
        private readonly IMoveInput _moveInput;
        private readonly IRotateInput _lookInput;
        private readonly Mover _mover;

        public MoverPresenter(Mover mover, IMoveInput moveInput, IRotateInput lookInput)
        {
            _mover = mover;
            _moveInput = moveInput;
            _moveInput.MoveReceived += OnMove;
            _lookInput = lookInput;
            _lookInput.RotationReceived += OnLook;
        }

        public void Dispose()
        {
            _moveInput.MoveReceived -= OnMove;
            _lookInput.RotationReceived -= OnLook;
        }

        private void OnMove(Vector2 direction)
        {
            _mover.MoveHorizontal(direction);
        }

        private void OnLook(Vector2 direction)
        {
            _mover.RotateHorizontal(direction);
        }
    }
}
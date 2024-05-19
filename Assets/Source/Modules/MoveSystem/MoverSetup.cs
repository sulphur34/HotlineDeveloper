using System;
using Modules.InputSystem.Interfaces;
using UnityEngine;
using UnityEngine.PlayerLoop;
using VContainer;

namespace Modules.MoveSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class MoverSetup : MonoBehaviour
    {
        private MoverPresenter _moverPresenter;

        [Inject]
        public void Construct(MoverConfig moverConfig, IMoveInput moveInput, IRotateInput rotateInput)
        {
            var characterController = GetComponent<CharacterController>();
            Mover mover = new Mover(characterController, transform, moverConfig);
            _moverPresenter = new MoverPresenter(mover, moveInput, rotateInput);
        }

        public void OnDestroy()
        {
            _moverPresenter.Dispose();
        }
    }
}
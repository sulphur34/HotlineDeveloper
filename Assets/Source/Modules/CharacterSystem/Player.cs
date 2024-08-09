using System;
using Modules.DamagerSystem;
using Modules.InputSystem.PlayerInput;
using UnityEngine;

namespace Modules.CharacterSystem
{
    public class Player : MonoBehaviour
    {
        private InputController _inputController;
        private DamageReceiverView _damageReceiverView;
        
        private void Awake()
        {
            _inputController = GetComponent<InputController>();
            _damageReceiverView = GetComponent<DamageReceiverView>();
            _damageReceiverView.FallenDown += OnFall;
            _damageReceiverView.Recovered += OnRecover;
        }

        private void OnDestroy()
        {
            _damageReceiverView.FallenDown -= OnFall;
            _damageReceiverView.Recovered -= OnRecover;
        }

        private void OnFall()
        {
            _inputController.enabled = false;
        }

        private void OnRecover()
        {
            _inputController.enabled = true;
        }
    }
}
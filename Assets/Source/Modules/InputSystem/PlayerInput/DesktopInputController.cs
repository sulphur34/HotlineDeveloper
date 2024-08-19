using UnityEngine;
using UnityEngine.EventSystems;

namespace Modules.InputSystem.PlayerInput
{
    public class DesktopInputController : InputController
    {
        private readonly Vector2 _vectorOne = new Vector2(1.0f, 1.0f);
        private readonly float _screenToVirtualMultiplier = 2f;

        private Vector2 MiddleScreenPoint => new Vector2(Width / 2, Height / 2);

        private void OnEnable()
        {
            PlayerInput.PlayerDesktop.Pick.performed += OnPick;
            PlayerInput.PlayerDesktop.Finish.performed += OnFinish;
            PlayerInput.Enable();
        }

        protected override void OnDisable()
        {
            PlayerInput.PlayerDesktop.Pick.performed -= OnPick;
            PlayerInput.PlayerDesktop.Finish.performed -= OnFinish;
            base.OnDisable();
        }

        protected override Vector2 OnMove()
        {
            return PlayerInput.PlayerDesktop.Move.ReadValue<Vector2>();
        }

        protected override Vector2 OnRotate()
        {
            Vector2 direction = PlayerInput.PlayerDesktop.Rotate.ReadValue<Vector2>();
            direction = new Vector2(direction.x / Screen.width, direction.y / Screen.height);
            direction = direction * _screenToVirtualMultiplier - _vectorOne;
            Vector2 modifiedDirection = new Vector2(direction.x * Width, direction.y * Height);
            return modifiedDirection;
        }

        protected override Vector2 OnLook()
        {
            return PlayerInput.PlayerDesktop.Look.ReadValue<Vector2>();
        }

        protected override Vector2 OnFarLook()
        {
            Vector2 position = PlayerInput.PlayerDesktop.FarLook.ReadValue<Vector2>();
            return position == Vector2.zero ? MiddleScreenPoint : position;
        }

        protected override void OnAttack()
        {
            if (PlayerInput.PlayerDesktop.Attack.IsPressed() == false)
                return;

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Attack();
        }
    }
}
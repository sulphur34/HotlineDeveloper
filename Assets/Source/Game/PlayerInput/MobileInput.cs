using UnityEngine;
using UnityEngine.InputSystem;

public class MobileInput : InputController
{
    protected override Vector2 OnMove()
    {
        return _playerInput.PlayerMobile.Move.ReadValue<Vector2>();
    }
    
    private void OnEnable()
    {
        _playerInput.PlayerMobile.Attack.performed += OnAttack;
        _playerInput.PlayerMobile.Pick.performed += OnPick;
        _playerInput.PlayerMobile.Finish.performed += OnFinish;
        _playerInput.Enable();
    }
    
    protected override Vector2 OnRotate()
    {
        return _playerInput.PlayerMobile.Rotate.ReadValue<Vector2>();
    }

    protected override Vector2 OnLook()
    {
        return _playerInput.PlayerMobile.Rotate.ReadValue<Vector2>();
    }

    protected override void OnAttack(InputAction.CallbackContext context)
    {
        if(context.ReadValue<Vector2>().magnitude > 0)
            base.OnAttack(context);
    }
}

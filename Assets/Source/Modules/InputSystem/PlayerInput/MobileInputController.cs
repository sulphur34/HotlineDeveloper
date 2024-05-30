using UnityEngine;
using UnityEngine.InputSystem;

public class MobileInputController : InputController
{
    private void OnEnable()
    {
        PlayerInput.PlayerMobile.Pick.performed += OnPick;
        PlayerInput.PlayerMobile.Finish.performed += OnFinish;
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.PlayerMobile.Pick.performed -= OnPick;
        PlayerInput.PlayerMobile.Finish.performed -= OnFinish;
    }
    
    protected override Vector2 OnMove()
    {
        return PlayerInput.PlayerMobile.Move.ReadValue<Vector2>();
    }

    protected override Vector2 OnRotate()
    {
        return PlayerInput.PlayerMobile.Rotate.ReadValue<Vector2>();
    }

    protected override Vector2 OnLook()
    {
        return PlayerInput.PlayerMobile.Move.ReadValue<Vector2>();
    }

    protected override void OnAttack()
    {
        if(PlayerInput.PlayerDesktop.Attack.ReadValue<Vector2>().magnitude > 0)
            Attack();
    }
}

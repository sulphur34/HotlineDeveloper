using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

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
        Vector2 direction = PlayerInput.PlayerMobile.Rotate.ReadValue<Vector2>();
        Vector2 modifiedDirection = new Vector2(direction.x * Width, direction.y * Height);
        return modifiedDirection;
    }

    protected override Vector2 OnLook()
    {
        return AlignInputToScreen(PlayerInput.PlayerMobile.Look.ReadValue<Vector2>(),Width,Height);
    }

    protected override Vector2 OnFarLook()
    {
        return AlignInputToScreen(PlayerInput.PlayerMobile.FarLook.ReadValue<Vector2>(),Width,Height);
    }

    protected override void OnAttack()
    {
        if (PlayerInput.PlayerMobile.Attack.ReadValue<Vector2>().magnitude > 0)
            Attack();
    }
}
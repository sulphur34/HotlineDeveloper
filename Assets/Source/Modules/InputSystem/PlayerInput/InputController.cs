using System;
using Modules.InputSystem.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputController : MonoBehaviour, IMoveInput, IAttackInput, IRotateInput, IPickInput, ILookInput, IFarLookInput
{
    protected PlayerInput PlayerInput;
    protected float Width => Screen.width;
    protected float Height => Screen.height;

    public event Action<Vector2> MoveReceived;
    public event Action<Vector2> RotationReceived;
    public event Action<Vector2> LookReceived;
    public event Action<Vector2> FarLookReceived;
    public event Action AttackReceived;
    public event Action PickReceived;
    public event Action FinishReceived;

    public void Awake()
    {
        PlayerInput = new PlayerInput();
    }

    private void Update()
    {
        MoveReceived?.Invoke(OnMove());
        RotationReceived?.Invoke(OnRotate());
        LookReceived?.Invoke(OnLook());
        FarLookReceived?.Invoke(OnFarLook());
        OnAttack();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    protected void Attack()
    {
        AttackReceived?.Invoke();
    }

    protected void OnPick(InputAction.CallbackContext context)
    {
        PickReceived?.Invoke();
    }

    protected void OnFinish(InputAction.CallbackContext context)
    {
        FinishReceived?.Invoke();
    }

    protected Vector2 AlignInputToScreen(Vector2 position, float widthRate = 1, float heightRate = 1, float directionRatio = 1f)
    {
        return new Vector2(position.x * widthRate + Width / 2 * directionRatio,
            position.y * heightRate + Height / 2 * directionRatio);
    }

    protected abstract void OnAttack();
    protected abstract Vector2 OnMove();
    protected abstract Vector2 OnRotate();
    protected abstract Vector2 OnLook();
    protected abstract Vector2 OnFarLook();
}
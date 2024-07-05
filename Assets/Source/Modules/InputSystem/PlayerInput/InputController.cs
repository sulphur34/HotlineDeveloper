using System;
using Modules.InputSystem.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputController : MonoBehaviour, IMoveInput, IAttackInput, IRotateInput, IPickInput
{
    protected PlayerInput PlayerInput;

    protected Camera Camera { get; private set; }
    public event Action<Vector2> MoveReceived;
    public event Action<Vector2> RotationReceived;
    public event Action<Vector2> LookReceived;
    public event Action AttackReceived;
    public event Action PickReceived;
    public event Action FinishReceived;

    private void Awake()
    {
        Camera = Camera.main;
        PlayerInput = new PlayerInput();
    }

    private void Update()
    {
        MoveReceived?.Invoke(OnMove());
        RotationReceived?.Invoke(OnRotate());
        LookReceived?.Invoke(OnLook());
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

    protected abstract void OnAttack();
    protected abstract Vector2 OnMove();
    protected abstract Vector2 OnRotate();
    protected abstract Vector2 OnLook();
}
using System;
using Modules.DamageSystem;
using Modules.MoveSystem;
using Source.Modules.InputSystem.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputController : MonoBehaviour, IMoveInput, IAttackInput, IRotateInput, IPickInput
{
    protected PlayerInput _playerInput;

    public event Action<Vector2> MoveReceived;
    public event Action<Vector2> RotationReceived;
    public event Action<Vector2> LookRecieved;
    public event Action AttackReceived;
    public event Action PickRecieved;
    public event Action FinishRecieved;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }
    
    private void Update()
    {
        MoveReceived?.Invoke(OnMove());
        RotationReceived?.Invoke(OnRotate());
        LookRecieved?.Invoke(OnLook());
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    protected abstract Vector2 OnMove();
    protected abstract Vector2 OnRotate();
    protected abstract Vector2 OnLook();
    
    protected virtual void OnAttack(InputAction.CallbackContext context)
    {
        AttackReceived?.Invoke();
    }

    protected void OnPick(InputAction.CallbackContext context)
    {
        PickRecieved?.Invoke();
    }

    protected void OnFinish(InputAction.CallbackContext context)
    {
        FinishRecieved?.Invoke();
    }
}

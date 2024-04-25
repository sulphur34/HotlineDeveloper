using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DesktopInputController : InputController
{
    private readonly Vector2 _vectorOne = new Vector2(1.0f, 1.0f);
    private readonly float _screenToVirtualMultiplier = 2f;
    
    private void OnEnable()
    {
        _playerInput.PlayerDesktop.Attack.performed += OnAttack;
        _playerInput.PlayerDesktop.Pick.performed += OnPick;
        _playerInput.PlayerDesktop.Finish.performed += OnFinish;
        _playerInput.Enable();
    }
    
    protected override Vector2 OnMove()
    {
        return _playerInput.PlayerDesktop.Move.ReadValue<Vector2>();
    }

    protected override Vector2 OnRotate()
    {
        Vector2 direction = _playerInput.PlayerDesktop.Rotate.ReadValue<Vector2>();
        direction = new Vector2(direction.x / Screen.width, direction.y / Screen.height);
        direction = direction * _screenToVirtualMultiplier - _vectorOne;
        return direction;
    }

    protected override Vector2 OnLook()
    {
        return _playerInput.PlayerDesktop.Look.ReadValue<Vector2>();
    }
}
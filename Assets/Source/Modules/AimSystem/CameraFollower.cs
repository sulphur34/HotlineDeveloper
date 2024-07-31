using System;
using Modules.InputSystem.Interfaces;
using UnityEngine;
using VContainer;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float _overviewRange = 30;
    [SerializeField] private float _lerpRate = 0.5f;
    
    private Transform _transform;
    private Camera _camera;
    private IFarLookInput _lookInput;

    [Inject]
    private void Construct(IFarLookInput lookInput)
    {
        _lookInput = lookInput;
        _transform = transform;
        _camera = Camera.main;
        _lookInput.FarLookReceived += UpdatePosition;
    }

    private void UpdatePosition(Vector2 lookPosition)
    {
        Vector3 playerPosition = new Vector3(transform.position.x, _camera.transform.position.y, _transform.position.z);
        Vector3 mousePosition = new Vector3(lookPosition.x,lookPosition.y, _camera.nearClipPlane + _overviewRange);
        Vector3 mouseWorldPoint = _camera.ScreenToWorldPoint(mousePosition);
        mouseWorldPoint.y = _camera.transform.position.y; 
        _camera.transform.position = Vector3.Lerp(playerPosition, mouseWorldPoint, _lerpRate);
    }
}
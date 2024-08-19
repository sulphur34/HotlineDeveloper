using System;
using Modules.InputSystem.Interfaces;
using UnityEngine;
using VContainer;

namespace Modules.AimSystem
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private float _overviewRange = 30;
        [SerializeField] private float _lerpRate = 0.5f;
        private Transform _transform;
        private Camera _camera;
        private Transform _cameraTransform;
        private IFarLookInput _lookInput;

        [Inject]
        private void Construct(IFarLookInput lookInput)
        {
            _transform = transform;
            _camera = Camera.main;
            _cameraTransform = _camera.transform;
            _lookInput = lookInput;
            _lookInput.FarLookReceived += UpdatePosition;
        }

        private void OnDestroy()
        {
            if (_lookInput != null)
                _lookInput.FarLookReceived -= UpdatePosition;
        }

        private void UpdatePosition(Vector2 lookPosition)
        {
            Vector3 playerPosition = new (transform.position.x, _camera.transform.position.y, _transform.position.z);
            Vector3 mousePosition = new (lookPosition.x, lookPosition.y, _camera.nearClipPlane + _overviewRange);
            Vector3 mouseWorldPoint = _camera.ScreenToWorldPoint(mousePosition);
            mouseWorldPoint.y = _cameraTransform.position.y;
            _cameraTransform.transform.position = Vector3.Lerp(playerPosition, mouseWorldPoint, _lerpRate);
        }
    }
}
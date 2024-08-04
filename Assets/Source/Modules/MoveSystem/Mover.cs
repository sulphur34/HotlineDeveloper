using System;
using UnityEngine;

namespace Modules.MoveSystem
{
    public class Mover : IMovable
    {
        private readonly float _gravityModifier = -0.08f;
        private CharacterController _characterController;
        private Transform _transform;
        private Transform _torsoRotator;
        private float _moveMoveSpeed;

        public event Action<float> SpeedChange;

        public Mover(CharacterController characterController, Transform transform, Transform torsoRotator, MoverConfig config)
        {
            _characterController = characterController;
            _transform = transform;
            _moveMoveSpeed = config.MoveSpeed;
            _torsoRotator = torsoRotator;
        }

        public void RotateHorizontal(Vector2 direction)
        {
            RotateDirection(_torsoRotator, direction);
        }

        public void MoveHorizontal(Vector2 direction)
        {
            _characterController.Move(new Vector3(direction.x, _gravityModifier, direction.y) * _moveMoveSpeed * Time.deltaTime);
            SpeedChange?.Invoke(_characterController.velocity.magnitude);
            RotateDirection(_transform, direction);
        }
        
        private void AlignWithGround()
        {
            RaycastHit hit;
            if (Physics.Raycast(_transform.position, Vector3.down, out hit))
            {
                _transform.up = hit.normal;
            }
        }

        private void RotateDirection(Transform rotatedObject, Vector3 direction)
        {
            Vector2 normalized = direction.normalized;
            float angleRadians = Mathf.Atan2(normalized.x, normalized.y);
            float angleDegrees = angleRadians * Mathf.Rad2Deg;
            rotatedObject.eulerAngles = new Vector3(0f, angleDegrees, 0f);
        }
    }
}
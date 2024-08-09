using UnityEngine;

namespace Modules.MoveSystem
{
    public class Mover : IMovable
    {
        private readonly CharacterController _characterController;
        private readonly Transform _transform;
        private readonly Transform _torsoRotator;
        private readonly float _moveMoveSpeed;
        private readonly float _gravityModifier;

        public Mover(CharacterController characterController, Transform transform, Transform torsoRotator,
            MoverConfig config)
        {
            _characterController = characterController;
            _transform = transform;
            _moveMoveSpeed = config.MoveSpeed;
            _gravityModifier = config.GravityModifier;
            _torsoRotator = torsoRotator;
        }

        public void RotateHorizontal(Vector2 rotationValue)
        {
            RotateDirection(_torsoRotator, rotationValue);
        }

        public void MoveHorizontal(Vector2 direction)
        {
            _characterController.Move(
                new Vector3(direction.x, _gravityModifier, direction.y) * _moveMoveSpeed * Time.deltaTime);
            RotateDirection(_transform, direction);
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
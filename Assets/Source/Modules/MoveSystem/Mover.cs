using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Modules.MoveSystem
{
    public class Mover : IMovable
    {
        private readonly float _gravityModifier = -0.08f;
        private CharacterController _characterController;
        private Transform _transform;
        private float _moveMoveSpeed;
        private float _rotationSpeed;

        public Mover(CharacterController characterController, Transform transform, MoverConfig config)
        {
            _characterController = characterController;
            _transform = transform;
            _moveMoveSpeed = config.MoveSpeed;
            _rotationSpeed = config.RotationSpeed;
        }

        public void RotateHorizontal(Vector2 direction)
        {
            Vector2 normalized = direction.normalized;
            float angleRadians = Mathf.Atan2(normalized.x, normalized.y);
            float angleDegrees = angleRadians * Mathf.Rad2Deg;
            _transform.eulerAngles = new Vector3(0f, angleDegrees, 0f);
        }

        public void MoveHorizontal(Vector2 direction)
        {
            _characterController.Move(new Vector3(direction.x, _gravityModifier, direction.y) * _moveMoveSpeed * Time.deltaTime);
        }
        
        private void AlignWithGround()
        {
            RaycastHit hit;
            if (Physics.Raycast(_transform.position, Vector3.down, out hit))
            {
                Debug.Log(hit.distance);
                
                _transform.up = hit.normal;
            }
        }
    }
}
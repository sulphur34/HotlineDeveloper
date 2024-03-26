using UnityEngine;
using VContainer;

namespace Modules.MoveSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Mover : IMovable
    {
        private Rigidbody _rigidbody;
        private float _moveMoveSpeed;
        private float _rotationSpeed;

        
        public Mover(Rigidbody rigidbody, MoverConfig config)
        {
            _rigidbody = rigidbody;
            _moveMoveSpeed = config.MoveSpeed;
            _rotationSpeed = config.RotationSpeed;
        }

        public void RotateHorizontal(float rotationValue)
        {
            Rotate(new Vector3(0, rotationValue, 0));
        }

        public void MoveHorizontal(Vector2 direction)
        {
            Move(new Vector3(direction.x, 0f, direction.y));
        }
        
        private void Move(Vector3 direction)
        {
            Vector3 normalized = direction.normalized * _moveMoveSpeed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + normalized);
        }

        private void Rotate(Vector3 direction)
        {
            Quaternion rotation = Quaternion.Euler(direction  * _rotationSpeed);
            _rigidbody.MoveRotation(_rigidbody.rotation * rotation);
        }
    }
}
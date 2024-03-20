using UnityEngine;

namespace Modules.MoveSystem
{
    public class Mover : IMover
    {
        private Rigidbody _rigidbody;
        private float _moveMoveSpeed;
        private float _rotationSpeed;

        public Mover(Rigidbody rigidbody, float moveSpeed = 1, float rotationSpeed = 1)
        {
            _rigidbody = rigidbody;
            _moveMoveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
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
using UnityEngine;

namespace Modules.Items.Weapons
{
    internal class Bullet : MonoBehaviour
    {
        [SerializeField] public Rigidbody _rigidbody;

        internal void Init(Vector3 direction, float speed)
        {
            _rigidbody.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            _rigidbody.velocity = direction * speed;
        }

        internal void SetPosition(Vector3 position)
        {
            _rigidbody.position = position;
        }
    }
}
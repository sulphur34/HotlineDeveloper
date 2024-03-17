using UnityEngine;

namespace Modules.Items.Weapons
{
    internal class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        internal void Init(float speed)
        {
            _rigidbody.velocity = new Vector3(0, 0, speed);
        }
    }
}
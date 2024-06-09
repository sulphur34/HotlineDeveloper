using System;
using System.Collections;
using UnityEngine;

namespace Modules.BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _lifetime;
        
        private WaitForSeconds _waitlifetime;

        public event Action<Bullet> LifespanEnded;

        private void OnCollisionEnter(Collision collision)
        {
            // if (collision.collider.TryGetComponent(out IBulletDestroyer _))
                LifespanEnded?.Invoke(this);
        }

        public void Init(Vector3 direction, float speed)
        {
            _waitlifetime = new WaitForSeconds(_lifetime);
            StartCoroutine(StartLifetime());

            _rigidbody.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            _rigidbody.velocity = direction * speed;
        }

        public void SetPosition(Vector3 position)
        {
            _rigidbody.position = position;
        }

        public void SetInterpolation(RigidbodyInterpolation interpolation)
        {
            _rigidbody.interpolation = interpolation;
        }

        private IEnumerator StartLifetime()
        {
            yield return _waitlifetime;
            LifespanEnded?.Invoke(this);
        }
    }
}
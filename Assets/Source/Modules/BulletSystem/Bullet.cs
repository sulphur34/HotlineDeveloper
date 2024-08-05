using System;
using System.Collections;
using UnityEngine;

namespace Modules.BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _lifetime;
        [SerializeField] private BulletParticleController _particleController;
        [field: SerializeField] public Collider Collider { get; private set; }

        private WaitForSeconds _waitLifetime;
        private Coroutine _coroutine;
        
        public event Action<Bullet> LifespanEnded;

        private void OnTriggerEnter(Collider other)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            
            _particleController.DeactivateParticle();
            
            LifespanEnded?.Invoke(this);
        }

        public void Init(Vector3 direction, float speed)
        {
            _waitLifetime = new WaitForSeconds(_lifetime);
            _coroutine = StartCoroutine(StartLifetime());
            _rigidbody.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            _rigidbody.velocity = direction * speed;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
            _particleController.ActivateParticle();
        }

        private IEnumerator StartLifetime()
        {
            yield return _waitLifetime;
            LifespanEnded?.Invoke(this);
        }
    }
}
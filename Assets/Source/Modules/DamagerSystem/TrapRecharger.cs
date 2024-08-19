using System.Collections;
using Modules.DamagerSystem;
using UnityEngine;

namespace Modules.DamagerSystem
{
    [RequireComponent(typeof(Collider))]
    public class TrapRecharger : MonoBehaviour
    {
        [SerializeField] private EnemyTrapStrategy _trapStrategy;
        [SerializeField] private ParticleSystem _trapParticle;
        [SerializeField] private float _rechargeTime;

        private Collider _collider;
        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds;

        private void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_rechargeTime);
            _collider = GetComponent<Collider>();
            _trapStrategy.EnemyDamaged += OnEnemyDamage;
        }

        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private void OnEnemyDamage()
        {
            _coroutine = StartCoroutine(RechargingRoutine());
        }

        private IEnumerator RechargingRoutine()
        {
            _trapParticle.Stop();
            _collider.enabled = false;
            yield return _waitForSeconds;
            _trapParticle.Play();
            _collider.enabled = true;
        }
    }
}
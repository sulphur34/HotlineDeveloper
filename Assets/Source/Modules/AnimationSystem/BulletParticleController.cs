using System.Collections;
using Modules.BulletSystem;
using UnityEngine;

namespace Source.Modules.EffectsSystem
{
    public class BulletParticleController : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private ParticleSystem _particleSystem;

        private Coroutine _coroutine;
        private ParticleSystem.MinMaxCurve _trailWidth;
        
        private void Awake()
        {
            _bullet.LifespanEnded += DeactivateParticle;
            _bullet.LifespanStarted += ActivateParticle;
            _trailWidth = _particleSystem.trails.widthOverTrail;
            DeactivateParticle(_bullet);
        }

        private void OnDestroy()
        {
            _bullet.LifespanEnded -= DeactivateParticle;
            _bullet.LifespanStarted -= ActivateParticle;
        }

        private void DeactivateParticle(Bullet bullet)
        {
            _particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            _particleSystem.Clear();
            var trails = _particleSystem.trails;
            trails.enabled = false;
            trails.widthOverTrail = new ParticleSystem.MinMaxCurve(0f);
        }

        private void ActivateParticle(Bullet bullet)
        {
            _particleSystem.Clear();
            _particleSystem.Play();
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _coroutine = StartCoroutine(ReEnableTrails());
        }

        private IEnumerator ReEnableTrails()
        {
            yield return null;
            var trails = _particleSystem.trails;
            trails.enabled = true;
            trails.widthOverTrail = _trailWidth;
        }
    }
}
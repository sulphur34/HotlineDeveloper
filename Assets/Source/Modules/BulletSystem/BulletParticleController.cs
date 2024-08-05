using UnityEngine;

namespace Modules.BulletSystem
{
    internal class BulletParticleController : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trailRenderer;

        private Coroutine _coroutine;
        private ParticleSystem.MinMaxCurve _trailWidth;

        internal void DeactivateParticle()
        {
            _trailRenderer.Clear();
            _trailRenderer.enabled = false;
        }

        internal void ActivateParticle()
        {
            _trailRenderer.Clear();
            _trailRenderer.enabled = true;
        }
    }
}
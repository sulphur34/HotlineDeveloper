using UnityEngine;

namespace Game.Scripts.EffectsSystem
{
    public class SwingParticleController : MonoBehaviour
    {
        private Collider _collider;
        private ParticleSystem _particleSystem;

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _particleSystem = GetComponent<ParticleSystem>();
            SetParticleSystemState();
        }

        private void Update()
        {
            SetParticleSystemState();
        }

        private void SetParticleSystemState()
        {
            if (_collider.enabled)
                _particleSystem.Play();
            else
                _particleSystem.Stop();
        }
    }
}
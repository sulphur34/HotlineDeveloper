using System;
using Modules.CharacterSystem;
using UnityEngine;
using VContainer;

namespace Modules.LevelsSystem
{
    [RequireComponent(typeof(Collider))]
    public class EndLevelTrigger : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _activationParticle;
        [SerializeField] private Canvas _activationCanvas;

        private Collider _collider;

        public event Action Enabled;

        public event Action Reached;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player _))
            {
                Reached?.Invoke();
            }
        }

        [Inject]
        public void Construct(EnemyTracker enemyTracker)
        {
            enemyTracker.AllEnemiesDied += Activate;
            _collider = GetComponent<Collider>();
            Deactivate();
        }

        private void Activate()
        {
            SetState(true);
            Enabled?.Invoke();
        }

        private void Deactivate()
        {
            SetState(false);
        }

        private void SetState(bool isActive)
        {
            _collider.enabled = isActive;
            _activationCanvas.enabled = isActive;

            if (isActive)
                _activationParticle.Play();
            else
                _activationParticle.Stop();
        }
    }
}
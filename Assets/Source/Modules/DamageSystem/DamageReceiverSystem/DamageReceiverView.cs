using System;
using Source.Game.Scripts.Animations;
using UnityEngine;

namespace Modules.DamageSystem
{
    [RequireComponent(typeof(Collider))]
    public class DamageReceiverView : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private ParticleSystem _bloodParticlePrefab;
        [SerializeField] private Collider _collider;
        
        public event Action<DamageData> Received;
        public event Action FallenDown;
        public event Action Recovered;
        
        public bool IsDead { get; private set; }
        public bool IsKnocked { get; private set; }

        public void Receive(DamageData damageData)
        {
            if (damageData.IsKnockout == false && IsDead == false)
                Instantiate(_bloodParticlePrefab, transform);
            
            Received?.Invoke(damageData);
        }
       
        public void OnKnocked()
        {
            IsKnocked = true;
            OnFall();
        }

        public void OnRecovered()
        {
            _collider.enabled = true;
            IsKnocked = false;
            _animationController.StandUp();
            Recovered?.Invoke();
        }

        public void OnHealthChanged(float value)
        {
        }

        public void OnDeath()
        {
            IsDead = true;
            OnFall();
        }

        private void OnFall()
        {
            _collider.enabled = false;
            FallenDown?.Invoke();
            _animationController.FallDown();
        }
    }
}
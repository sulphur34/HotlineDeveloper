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
        
        public event Action<DamageData> Received;
        public event Action FallenDown;
        
        public bool IsDead { get; private set; }
        public bool IsKnocked { get; private set; }

        public void Receive(DamageData damageData)
        {
            if (damageData.IsKnockout == false)
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
            IsKnocked = false;
            _animationController.StandUp();
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
            FallenDown?.Invoke();
            _animationController.FallDown();
        }
    }
}
using System;
using Source.Game.Scripts.Animations;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.DamageSystem
{
    [RequireComponent(typeof(Collider))]
    public class DamageReceiverView : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private AnimationController _animationController;
        public event Action<DamageData> Received;
        public event Action FallenDown;
        public event Action StoodUp;
        
        public bool IsDead { get; private set; }
        public bool IsKnocked { get; private set; }

        public void Receive(DamageData damageData)
        {
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
            StoodUp?.Invoke();
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
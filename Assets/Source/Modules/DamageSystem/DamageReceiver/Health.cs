using System;
using UnityEngine;

namespace Modules.DamageSystem
{
    public class Health
    {
        private readonly float _minHealth;
        private readonly float _maxHealth;

        private float _currentHealth;
        

        public Health(float maxHealth, float minHealth = 0f)
        {
            _minHealth = minHealth;
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
            IsDead = false;
        }

        public bool IsDead { get; private set; }

        public void TakeDamage(float damage, Action<float> onChangedCallback, Action onDieCallback)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException();

            if (IsDead)
                return;

            _currentHealth = Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);
            onChangedCallback?.Invoke(_currentHealth);

            if (_currentHealth <= _minHealth)
            {
                IsDead = true;
                onDieCallback?.Invoke();
            }
        }

        public void Execute(Action<float> OnChangedCallback, Action OnDieCallback)
        {
            TakeDamage(_currentHealth, OnChangedCallback, OnDieCallback);
        }
    }
}
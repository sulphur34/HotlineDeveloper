using System;
using UnityEngine;

namespace Modules.DamageSystem
{
    public class Health : IDamageable
    {
        private readonly float _minHealth;
        private readonly float _maxHealth;

        private float _currentHealth;
        private bool _isDead;

        public Health(float maxHealth, float minHealth = 0f)
        {
            _minHealth = minHealth;
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
            _isDead = false;
        }

        public event Action Died;
        public event Action<float> Changed;

        public void TakeDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException();

            if (_isDead)
                return;

            _currentHealth = Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);
            Changed?.Invoke(_currentHealth);

            if (_currentHealth <= _minHealth)
            {
                _isDead = true;
                Died?.Invoke();
            }
        }

        public void Execute()
        {
            TakeDamage(_currentHealth);
        }
    }
}
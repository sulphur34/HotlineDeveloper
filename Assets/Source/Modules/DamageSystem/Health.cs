using System;
using UnityEngine;

namespace Modules.DamageSystem
{
    internal class Health : IDamageable
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

        public void TakeDamage(Damage damage)
        {
            if (damage.Value < 0)
                throw new ArgumentOutOfRangeException();

            if (_isDead)
                return;

            if (damage.IsLethal)
            {
                _currentHealth = _minHealth;
            }
            else
            {
                _currentHealth = Mathf.Clamp(_currentHealth -= damage.Value, _minHealth, _maxHealth);
                Changed?.Invoke(_currentHealth);
            }

            if (_currentHealth <= _minHealth)
            {
                _isDead = true;
                Died?.Invoke();
            }
        }
    }
}
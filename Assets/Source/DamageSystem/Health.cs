using System;
using Source.DamageSystem;
using UnityEngine;

public class Health : IDamageable
{
    private readonly float _minHealth;
    private readonly float _maxHealth;

    private float _currentHealth;
    private bool _isDead;
    private bool _isConscious;

    public Health(float maxHealth, float minHealth = 0f)
    {
        _minHealth = minHealth;
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
        _isConscious = true;
        _isDead = false;
    }

    public event Action Died;
    public event Action<float> HealthChanged;

    public void TakeDamage(IDamage damage)
    {
        if(_isDead)
            return;

        if (damage.IsLethal == false)
        {
            _isConscious = false;
            return;
        }

        if (damage.Value < 0)
            throw new ArgumentOutOfRangeException();

        _currentHealth = Mathf.Clamp(_currentHealth -= damage.Value, _minHealth, _maxHealth);
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= _minHealth)
        {
            _isDead = true;
            Died?.Invoke();
        }
    }
}
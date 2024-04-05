namespace Modules.DamageSystem
{
    public class HealthPresenter
    {
        private Health _health;
        private HealthView _healthView;
        
        public HealthPresenter(Health health, HealthView healthView)
        {
            _health = health;
            _healthView = healthView;
            _health.Changed += OnUpdate;
            _health.Died += OnDeath;
        }

        private void OnUpdate(float value)
        {
            _healthView.OnUpdate(value);
        }

        private void OnDeath()
        {
            _healthView.OnDeath();
        }

        public void Dispose()
        {
            _health.Changed -= OnUpdate;
            _health.Died -= OnDeath;
        }
    }
}
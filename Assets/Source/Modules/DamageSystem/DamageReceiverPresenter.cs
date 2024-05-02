using Modules.Characters;

namespace Source.Modules.DamageSystem
{
    public class DamageReceiverPresenter
    {
        private DamageReceiver _damageReceiver;
        private DamageReceiverView _damageReceiverView;
        
        public DamageReceiverPresenter(DamageReceiver damageReceiver, DamageReceiverView damageReceiverView)
        {
            _damageReceiver = damageReceiver;
            _damageReceiverView = damageReceiverView;
            _damageReceiver.Died += OnDeath;
            _damageReceiver.HealthChanged += OnHealthUpdate;
            _damageReceiver.Knocked += OnKnocked;
            _damageReceiver.Recovered += OnRecovered;
            _damageReceiverView.Received += _damageReceiver.Receive;
        }

        private void OnHealthUpdate(float value)
        {
            _damageReceiverView.OnHealthChanged(value);
        }

        private void OnDeath()
        {
            _damageReceiverView.OnDeath();
        }

        private void OnKnocked()
        {
            _damageReceiverView.OnKnocked();
        }

        private void OnRecovered()
        {
            _damageReceiverView.OnRecovered();
        }

        public void Dispose()
        {
            _damageReceiver.Died -= OnDeath;
            _damageReceiver.HealthChanged -= OnHealthUpdate;
            _damageReceiver.Knocked -= OnKnocked;
            _damageReceiver.Recovered -= OnRecovered;
            _damageReceiverView.Received += _damageReceiver.Receive;
        }
    }
}
namespace Modules.DamageReceiverSystem
{
    internal class DamageReceiverPresenter
    {
        private DamageReceiver _damageReceiver;
        private DamageReceiverView _damageReceiverView;
        
        internal DamageReceiverPresenter(DamageReceiver damageReceiver, DamageReceiverView damageReceiverView)
        {
            _damageReceiver = damageReceiver;
            _damageReceiverView = damageReceiverView;
            _damageReceiver.Died += OnDeath;
            _damageReceiver.Knocked += OnKnocked;
            _damageReceiver.Recovered += OnRecovered;
            _damageReceiverView.Received += _damageReceiver.Receive;
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
            _damageReceiver.Knocked -= OnKnocked;
            _damageReceiver.Recovered -= OnRecovered;
            _damageReceiverView.Received -= _damageReceiver.Receive;
        }
    }
}
using System;

namespace Modules.DamageReceiverSystem
{
    internal class DamageReceiverPresenter : IDisposable
    {
        private readonly DamageReceiver _damageReceiver;
        private readonly DamageReceiverView _damageReceiverView;

        internal DamageReceiverPresenter(DamageReceiver damageReceiver, DamageReceiverView damageReceiverView)
        {
            _damageReceiver = damageReceiver;
            _damageReceiverView = damageReceiverView;
            _damageReceiver.Died += OnDeath;
            _damageReceiver.Knocked += OnKnocked;
            _damageReceiver.Recovered += OnRecovered;
            _damageReceiverView.Received += _damageReceiver.Receive;
        }

        public void Dispose()
        {
            _damageReceiver.Died -= OnDeath;
            _damageReceiver.Knocked -= OnKnocked;
            _damageReceiver.Recovered -= OnRecovered;
            _damageReceiverView.Received -= _damageReceiver.Receive;
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
    }
}
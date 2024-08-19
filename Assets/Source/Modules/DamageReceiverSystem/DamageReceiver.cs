using System;
using System.Threading;
using Modules.DamageReceiverSystem.DamageReceiveStrategies;

namespace Modules.DamageReceiverSystem
{
    internal class DamageReceiver
    {
        private readonly Health _health;
        private readonly Consciousness _consciousness;
        private readonly IDamageReceiveStrategy _damageReceiveStrategy;

        public DamageReceiver(DamageableConfig damageableConfig, CancellationToken cancellationToken)
        {
            _health = new Health(damageableConfig.MaxValue);
            _consciousness = new Consciousness(damageableConfig.RecoverTime, cancellationToken);
            _damageReceiveStrategy = damageableConfig.DamageReceiveStrategy;
        }

        public event Action Died;

        public event Action Knocked;

        public event Action Recovered;

        public void Receive(DamageData damage)
        {
            if (_health.IsDead)
                return;

            DamageData modifiedDamage = _damageReceiveStrategy.GetDamage(damage);

            if (modifiedDamage.IsLethal || _consciousness.IsKnocked)
            {
                _health.Execute(Died);
                return;
            }

            if (modifiedDamage.IsKnockout && _consciousness.IsKnocked == false)
                _consciousness.Knockout(Knocked, Recovered);

            _health.TakeDamage(modifiedDamage.Value, Died);
        }
    }
}
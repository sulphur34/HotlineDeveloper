using System;
using System.Threading;
using Modules.DamageSystem.DamageStrategy;
using Source.Modules.DamageSystem;

namespace Modules.DamageSystem
{
    public class DamageReceiver
    {
        private Health _health;
        private Consciousness _consciousness;
        private IDamageStrategy _damageStrategy;

        public event Action<float> HealthChanged;
        public event Action Died;
        public event Action Knocked;
        public event Action Recovered; 

        public DamageReceiver(DamageableConfig damageableConfig, CancellationToken cancellationToken)
        {
            _health = new Health(damageableConfig.MaxValue);
            _consciousness = new Consciousness(damageableConfig.RecoverTime, cancellationToken);
            _damageStrategy = damageableConfig.DamageStrategy;
        }

        public void Receive(DamageData damage)
        {
            if (damage.IsLethal && _consciousness.IsConscious == false)
                _health.Execute(HealthChanged,Died);
            
            if(damage.IsKnockout && _consciousness.IsConscious)
                _consciousness.Knockout(Knocked, Recovered);
            
            _health.TakeDamage(damage.Value, HealthChanged,Died);
        }
    }
}
using BehaviorDesigner.Runtime.Tasks;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    public class IsDead : Conditional
    {
        private DamageReceiver _damageReceiver;

        private bool _isDead;
        
        public override void OnAwake()
        {
            _damageReceiver.Died += OnDeath;
        }

        public override TaskStatus OnUpdate()
        {
            return _isDead ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnBehaviorComplete()
        {
            _damageReceiver.Died -= OnDeath;
        }

        private void OnDeath()
        {
            _isDead = true;
        }
    }
}
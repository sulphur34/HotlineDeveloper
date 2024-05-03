using BehaviorDesigner.Runtime.Tasks;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    public class IsKnocked : Conditional
    {
        private DamageReceiver _damageReceiver;

        private bool _isKnocked;
        
        public override void OnAwake()
        {
            _damageReceiver.Knocked += OnKnocked;
            _damageReceiver.Recovered += OnRecovered;
        }

        public override TaskStatus OnUpdate()
        {
            return _isKnocked ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnBehaviorComplete()
        {
            _damageReceiver.Knocked -= OnKnocked;
            _damageReceiver.Recovered -= OnRecovered;
        }

        private void OnKnocked()
        {
            _isKnocked = true;
        }

        private void OnRecovered()
        {
            _isKnocked = false;
        }
    }
}
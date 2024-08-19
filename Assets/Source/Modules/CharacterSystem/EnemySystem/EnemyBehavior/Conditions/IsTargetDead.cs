using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.DamageReceiverSystem;
using Modules.DamagerSystem;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsTargetDead")]
    public class IsTargetDead : Conditional
    {
        public SharedGameObject Target;

        private DamageReceiverView _playerDamageReceiverView;

        public override void OnStart()
        {
            if (_playerDamageReceiverView == null)
                _playerDamageReceiverView = Target.Value.GetComponent<DamageReceiverView>();
        }

        public override TaskStatus OnUpdate()
        {
            return _playerDamageReceiverView.IsDead ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
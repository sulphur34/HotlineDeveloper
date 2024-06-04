using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.DamageSystem;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsTargetDead")]
    public class IsTargetDead : Conditional
    {
        public SharedGameObject Target;

        private DamageReceiverView _playerDamageReceiverView;

        public override void OnAwake()
        {
            _playerDamageReceiverView = Target.Value.GetComponent<DamageReceiverView>();
        }

        public override TaskStatus OnUpdate()
        {
            return _playerDamageReceiverView.IsDead ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
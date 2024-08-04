using BehaviorDesigner.Runtime.Tasks;
using Modules.DamageReceiverSystem;
using Modules.DamageReceiverSystem.Enemies.EnemyBehavior.Variables;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsDead")]
    public class IsDead : Conditional
    {
        public SharedDamageReceiver DamageReceiver;

        public override void OnAwake()
        {
            DamageReceiver.Value = GetComponent<DamageReceiverView>();
        }

        public override TaskStatus OnUpdate()
        {
            return DamageReceiver.Value.IsDead ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
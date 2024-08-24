using BehaviorDesigner.Runtime.Tasks;
using Modules.CharacterSystem.EnemySystem.EnemyBehavior.Variables;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsDead")]
    public class IsDead : Conditional
    {
        public SharedDamageReceiver DamageReceiver;

        public override TaskStatus OnUpdate()
        {
            return DamageReceiver.Value.IsDead ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
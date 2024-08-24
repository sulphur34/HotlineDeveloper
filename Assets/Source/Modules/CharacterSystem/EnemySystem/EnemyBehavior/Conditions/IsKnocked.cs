using BehaviorDesigner.Runtime.Tasks;
using Modules.CharacterSystem.EnemySystem.EnemyBehavior.Variables;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsKnocked")]
    public class IsKnocked : Conditional
    {
        public SharedDamageReceiver DamageReceiver;

        public override TaskStatus OnUpdate()
        {
            return DamageReceiver.Value.IsKnocked ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
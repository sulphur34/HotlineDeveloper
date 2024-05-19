using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("CanSearch")]
    public class CanSearch : Conditional
    {
        public SharedBool HasLastPosition;

        public override TaskStatus OnUpdate()
        {
            return HasLastPosition.Value ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
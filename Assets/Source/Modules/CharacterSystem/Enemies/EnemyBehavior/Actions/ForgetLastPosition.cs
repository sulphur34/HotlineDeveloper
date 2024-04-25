using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    public class ForgetLastPosition : Action
    {
        public SharedBool HasLastPosition;

        public override TaskStatus OnUpdate()
        {
            HasLastPosition.Value = false;
            return TaskStatus.Success;
        }
    }
}
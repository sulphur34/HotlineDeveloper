using System.Linq;
using BehaviorDesigner.Runtime.Tasks;
using Modules.Characters.Enemies.EnemyBehavior.Variables;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("HasPatrolRoute")]
    public class HasPatrolRoute : Conditional
    {
        public SharedVector3Array PatrolPoints;

        public override TaskStatus OnUpdate()
        {
            int count = PatrolPoints.Value.ToList().Count;
            return PatrolPoints.Value.ToList().Count > 0 ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
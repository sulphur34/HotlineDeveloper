using System.Linq;
using BehaviorDesigner.Runtime.Tasks;
using Modules.CharacterSystem.EnemySystem.EnemyBehavior.Variables;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("HasPatrolRoute")]
    public class HasPatrolRoute : Conditional
    {
        public SharedVector3Array PatrolPoints;

        private bool _hasRoot;

        public override void OnAwake()
        {
            _hasRoot = PatrolPoints.Value.ToList().Count > 0;
        }

        public override TaskStatus OnUpdate()
        {
            return _hasRoot ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
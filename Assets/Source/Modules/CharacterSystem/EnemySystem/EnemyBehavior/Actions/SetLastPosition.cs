using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("SetLastPosition")]
    public class SetLastPosition : Action
    {
        public SharedVector3 LastTargetPosition;
        public SharedGameObject Target;
        public SharedBool HasLastPosition;

        public override TaskStatus OnUpdate()
        {
            if (Target != null)
            {
                LastTargetPosition.Value = Target.Value.transform.position;
                HasLastPosition.Value = true;
                return TaskStatus.Success;
            }

            LastTargetPosition.Value = Vector3.zero;
            HasLastPosition.Value = false;
            return TaskStatus.Failure;
        }
    }
}
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("Track")]
    public class Track : Action
    {
        public SharedGameObject Target;
        public SharedVector3 LastTargetPosition;
        public SharedBool HasLastPosition;

        private Transform _targetTransform;

        public override void OnStart()
        {
            _targetTransform = Target.Value.transform;
        }

        public override TaskStatus OnUpdate()
        {
            if (Target == null)
                return TaskStatus.Failure;

            LastTargetPosition.Value = _targetTransform.position;
            HasLastPosition.Value = true;
            return TaskStatus.Running;
        }
    }
}
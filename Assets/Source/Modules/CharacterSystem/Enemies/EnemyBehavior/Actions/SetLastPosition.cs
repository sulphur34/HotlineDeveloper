using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Source.Modules.CharacterSystem.Enemies.EnemyBehavior.Variables;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    public class SetLastPosition : Action
    {
        public SharedVector3 LastTargetPosition;
        public SharedGameObject Target;
        public SharedBool HasLastPosition;

        private Transform _transform;

        public override void OnAwake()
        {
            _transform = transform;
        }

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
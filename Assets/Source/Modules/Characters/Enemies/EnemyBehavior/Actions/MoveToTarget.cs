using System;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.MoveSystem;
using Source.Modules.InputSystem;
using UnityEngine;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("MoveToTarget")]
    public class MoveToTarget : Action
    {
        public SharedTransform Target;
        public SharedVector3 LastTargetPosition;
        public float MaxCloseMagnitude;

        private Transform _transform;
        private AiInput _input;

        public override void OnStart()
        {
            _transform = transform;
            _input = GetComponent<AiInput>();
        }

        public override TaskStatus OnUpdate()
        {
            Vector3 targetPosition = Target == null ? LastTargetPosition.Value : Target.Value.position;

            // if (Vector3.Magnitude(targetPosition - _transform.position) <= MaxCloseMagnitude)
            //     return TaskStatus.Success;
            
            Vector2 direction = GetDirection(targetPosition);
            // _input.ReceiveMove(direction * Time.deltaTime);
            return TaskStatus.Running;
        }

        private Vector2 GetDirection(Vector3 targetPosition)
        {
            Vector3 selfPosition = _transform.position;
            Vector2 targetPoint = new Vector2(targetPosition.x, targetPosition.z);
            Vector2 selfPoint = new Vector2(selfPosition.x, selfPosition.z);
            return (targetPoint - selfPoint).normalized;
        }
    }
}
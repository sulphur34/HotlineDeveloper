using System;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.MoveSystem;
using Source.Modules.InputSystem;
using UnityEngine;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    public class RotateToTarget : Action
    {
        public SharedTransform Target;
        public SharedVector3 LastTargetPosition;
        public float MaxCloseMagnitude;

        private Transform _transform;
        private AiInput _input;

        public override void OnStart()
        {
            _input = GetComponent<AiInput>();
            _transform = transform;
        }

        public override TaskStatus OnUpdate()
        {
            Vector3 targetPosition = Target == null ? LastTargetPosition.Value : Target.Value.position;

            // if (Vector3.Magnitude(targetPosition - _transform.position) <= MaxCloseMagnitude)
            //     return TaskStatus.Success;
            
            // _input.ReceiveRotation(GetDirection(targetPosition));
            return TaskStatus.Running;
        }

        private float GetDirection(Vector3 targetPosition)
        {
            Vector3 one = targetPosition;
            one.y = 0;
            Vector3 two = _transform.position;
            two.y = 0;
            Vector3 direction = one - two;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Debug.Log(rotation);
            return rotation.eulerAngles.y * Time.deltaTime;
        }
    }
}
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsInSight")]
    public class IsInSight : Conditional
    {
        public SharedGameObject Target;
        public SharedFloat VisualDistance;
        public SharedFloat FieldOfViewAngle;
        public Vector3 Offset;
        public Vector3 TargetOffset;

        private float _sqrDistance;
        private Transform _transform;

        public override void OnAwake()
        {
            _transform = transform;
        }

        public override void OnStart()
        {
            _sqrDistance = VisualDistance.Value * VisualDistance.Value;
        }

        public override TaskStatus OnUpdate()
        {
            Vector3 targetPosition = Target.Value.transform.position + TargetOffset;
            Vector3 selfPosition = _transform.position + Offset;

            Vector3 direction = targetPosition - selfPosition;
            float angle = Vector3.Angle(direction, _transform.forward);

            if (Physics.Linecast(selfPosition, targetPosition, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Player player) == false)
                    return TaskStatus.Failure;
            }

            float sqrMagnitude = Vector3.SqrMagnitude(targetPosition - selfPosition);

            if (sqrMagnitude > _sqrDistance || angle > FieldOfViewAngle.Value * 0.5f)
                return TaskStatus.Failure;

            return TaskStatus.Success;
        }
    }
}
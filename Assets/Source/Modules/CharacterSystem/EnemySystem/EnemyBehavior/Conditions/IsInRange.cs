using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Modules.CharacterSystem.Player;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsInRange")]
    public class IsInRange : Conditional
    {
        public SharedGameObject Target;
        public SharedFloat Distance;
        public bool LineOfSight;
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
            _sqrDistance = Distance.Value * Distance.Value;
        }

        public override TaskStatus OnUpdate()
        {
            Vector3 targetPosition = Target.Value.transform.position + TargetOffset;
            Vector3 selfPosition = _transform.position + Offset;
            float sqrMagnitude = Vector3.SqrMagnitude(targetPosition - selfPosition);

            if (sqrMagnitude > _sqrDistance)
                return TaskStatus.Failure;

            if (LineOfSight && Physics.Linecast(selfPosition, targetPosition, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Player player) == false)
                    return TaskStatus.Failure;
            }

            return TaskStatus.Success;
        }
    }
}
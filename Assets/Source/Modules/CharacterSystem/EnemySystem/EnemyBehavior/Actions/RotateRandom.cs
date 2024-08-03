using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("RotateRandom")]
    public class RotateRandom : Action
    {
        public float RotationTolerance = 0.5f;
        public float RotationDelta = 1f;
        public float MaxAxisValue = 100;
        public float MinAxisValue = 0;

        private Vector3 _direction;
        private Transform _transform;

        private float _randomAxisValue => Random.Range(MinAxisValue, MaxAxisValue);

        public override void OnAwake()
        {
            _transform = transform;
        }

        public override void OnStart()
        {
            _direction = GetRandomDirection();
        }

        public override TaskStatus OnUpdate()
        {
            Vector3 direction = (_direction - _transform.position);
            direction.y = 0;
            direction = direction.normalized;

            if (Vector3.Angle(_transform.forward, direction) <= RotationTolerance)
                return TaskStatus.Success;

            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, rotation, RotationDelta);
            return TaskStatus.Running;
        }

        private Vector3 GetRandomDirection()
        {
            return new Vector3(_randomAxisValue, _transform.position.y, _randomAxisValue);
        }
    }
}
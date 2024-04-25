using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    public class RotateRandom : Action
    {
        private readonly float _rotationTolerance = 0.5f;
        private readonly float _rotationDelta = 1f;
        private readonly float _maxAxisValue = 100;
        private readonly float _minAxisValue = 0;
        private Vector3 _direction;
        private Transform _transform;

        private float _randomAxisValue => Random.Range(_minAxisValue, _maxAxisValue);

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
            
            if (Vector3.Angle(_transform.forward, direction) <= _rotationTolerance)
                return TaskStatus.Success;

            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, rotation, _rotationDelta);
            return TaskStatus.Running;
        }

        private Vector3 GetRandomDirection()
        {
            return new Vector3(_randomAxisValue, _transform.position.y, _randomAxisValue);
        }
    }
}
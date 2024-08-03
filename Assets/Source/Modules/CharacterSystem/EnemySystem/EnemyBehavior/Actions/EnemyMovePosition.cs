using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("EnemyMovePosition")]
    public class EnemyMovePosition : Action
    {
        public SharedVector3 LastTargetPosition;
        public float MinStoppingDistance = 0.1f;

        private NavMeshAgent _navMeshAgent;
        private bool _isActive;
        private Transform _transform;

        public override void OnAwake()
        {
            _transform = transform;
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public override void OnStart()
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(LastTargetPosition.Value);
            _navMeshAgent.isStopped = false;
        }

        public override TaskStatus OnUpdate()
        {
            if (_navMeshAgent == null)
                return TaskStatus.Failure;

            Vector3 targetPosition = new(LastTargetPosition.Value.x, _transform.position.y,
                LastTargetPosition.Value.z);

            float distance = Vector3.Magnitude(targetPosition - _transform.position);

            if (distance - _navMeshAgent.stoppingDistance < MinStoppingDistance)
                return TaskStatus.Success;

            return TaskStatus.Running;
        }

        public override void OnConditionalAbort()
        {
            if (_navMeshAgent.isStopped)
                return;

            _navMeshAgent.isStopped = true;
        }
    }
}
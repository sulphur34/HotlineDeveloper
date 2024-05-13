using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using Modules.Characters.Enemies.EnemyBehavior.Variables;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("EnemyPatrol")]
    public class EnemyPatrol : Action
    {
        public SharedVector3Array _patrolPoints;

        private NavMeshAgent _navMeshAgent;
        private bool _isActive;
        private Queue<Vector3> _route;
        private Transform _transform;

        public override void OnAwake()
        {
            _isActive = false;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _route = new Queue<Vector3>(_patrolPoints.Value);
            _transform = transform;
        }

        public override void OnStart()
        {
            SetDestination();
        }

        public override TaskStatus OnUpdate()
        {
            if (_navMeshAgent == null)
                return TaskStatus.Failure;

            // float distance = Vector3.Magnitude(_navMeshAgent.destination - _transform.position);
            
            if (_navMeshAgent.remainingDistance <= 0)
                SetDestination();

            return TaskStatus.Running;
        }

        public override void OnConditionalAbort()
        {
            _navMeshAgent.Stop();
        }

        private void SetDestination()
        {
            Vector3 nextPoint = _route.Dequeue();
            _route.Enqueue(nextPoint);
            _navMeshAgent.SetDestination(nextPoint);
            _navMeshAgent.isStopped = false;
            _isActive = true;
        }
    }
}
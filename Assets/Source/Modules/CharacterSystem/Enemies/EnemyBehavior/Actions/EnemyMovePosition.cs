using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    public class EnemyMovePosition : Action
    {
        public SharedVector3 LastTargetPosition;
        
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
            _navMeshAgent.SetDestination(LastTargetPosition.Value);
            _navMeshAgent.isStopped = false;
        }

        public override TaskStatus OnUpdate()
        {
            if (_navMeshAgent == null)
                return TaskStatus.Failure;

            float distance = Vector3.Magnitude(LastTargetPosition.Value - _transform.position);
            
            if (distance - _navMeshAgent.stoppingDistance < 1f)
                return TaskStatus.Success;

            return TaskStatus.Running;
        }

        public override void OnConditionalAbort()
        {
            if (_navMeshAgent.isStopped)
                return;
            
            _navMeshAgent.Stop();
        }
    }
}
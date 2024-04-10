using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    public class EnemyChase : Action
    {
        public SharedGameObject Target;

        private NavMeshAgent _navMeshAgent;
        private Transform _targetTransform;

        public override void OnAwake()
        {
            _targetTransform = Target.Value.transform;
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public override void OnStart()
        {
            _navMeshAgent.isStopped = false;
        }

        public override TaskStatus OnUpdate()
        {
            if (_navMeshAgent == null)
                return TaskStatus.Failure;
            
            _navMeshAgent.SetDestination(_targetTransform.position);
            return TaskStatus.Running;
        }

        public override void OnConditionalAbort()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}
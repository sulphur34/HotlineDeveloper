using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    public class Fall : Action
    {
        private NavMeshAgent _navMeshAgent;
        
        public override void OnAwake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public override void OnStart()
        {
            _navMeshAgent.isStopped = true;
        }

        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Running;
        }

        public override void OnConditionalAbort()
        {
            _navMeshAgent.isStopped = false;
        }
    }
}
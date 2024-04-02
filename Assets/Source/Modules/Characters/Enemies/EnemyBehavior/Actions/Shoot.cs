using BehaviorDesigner.Runtime.Tasks;
using Modules.DamageSystem;
using Source.Modules.InputSystem;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("Shoot")]
    public class Shoot : Action
    {
        public event System.Action AttackReceived;
        
        public override TaskStatus OnUpdate()
        {
            AttackReceived?.Invoke();
            return TaskStatus.Running;
        }

    }
}
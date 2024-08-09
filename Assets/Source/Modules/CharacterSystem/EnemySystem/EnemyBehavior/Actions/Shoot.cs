using BehaviorDesigner.Runtime.Tasks;
using Modules.CharacterSystem.EnemiySystem.EnemyBehavior.Variables;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("Shoot")]
    public class Shoot : Action
    {
        public SharedAiInput AiInput;
        
        public override TaskStatus OnUpdate()
        {
            AiInput.Value.ReceiveAttack();
            return TaskStatus.Running;
        }
    }
}
using BehaviorDesigner.Runtime.Tasks;
using Modules.Characters.Enemies.EnemyBehavior.Variables;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
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
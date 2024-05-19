using BehaviorDesigner.Runtime.Tasks;
using Modules.Characters.Enemies.EnemyBehavior.Variables;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    [TaskCategory("CustomTask")]
    [TaskName("Pick")]
    public class Pick : Action
    {
        public SharedAiInput AiInput;
        public override TaskStatus OnUpdate()
        {
            AiInput.Value.RecievePick();
            return TaskStatus.Success;
        }
    }
}
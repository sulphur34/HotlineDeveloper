using BehaviorDesigner.Runtime.Tasks;
using Modules.CharacterSystem.EnemiySystem.EnemyBehavior.Variables;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Actions
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
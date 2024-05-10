using BehaviorDesigner.Runtime.Tasks;
using Modules.Characters.Enemies.EnemyBehavior.Variables;
using Modules.PlayerWeaponsHandler;
using Modules.InputSystem;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
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
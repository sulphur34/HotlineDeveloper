using BehaviorDesigner.Runtime.Tasks;
using Modules.PlayerWeaponsHandler;
using Source.Modules.InputSystem;

namespace Modules.Characters.Enemies.EnemyBehavior.Actions
{
    public class Pick : Action
    {
        private AiInput _aiInput;
        public override TaskStatus OnUpdate()
        {
            _aiInput.RecievePick();
            return TaskStatus.Success;
        }
    }
}
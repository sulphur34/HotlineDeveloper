using BehaviorDesigner.Runtime;
using Modules.InputSystem;

namespace Modules.CharacterSystem.EnemiySystem.EnemyBehavior.Variables
{
    public class SharedAiInput : SharedVariable<AiInput>
    {
        public static implicit operator SharedAiInput(AiInput value)
        {
            return new SharedAiInput { Value = value };
        }
    }
}
using BehaviorDesigner.Runtime;
using Source.Modules.InputSystem;

namespace Modules.Characters.Enemies.EnemyBehavior.Variables
{
    public class SharedAiInput : SharedVariable<AiInput>
    {
        public static implicit operator SharedAiInput(AiInput value) { return new SharedAiInput { Value = value }; }
    }
}
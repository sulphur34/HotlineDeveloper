using BehaviorDesigner.Runtime.Tasks;
using Modules.DamagerSystem.Enemies.EnemyBehavior.Variables;

namespace Modules.CharacterSystem.EnemiySystem.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsKnocked")]
    public class IsKnocked : Conditional
    {
        public SharedDamageReceiver DamageReceiver;
        
        public override TaskStatus OnUpdate()
        {
            return DamageReceiver.Value.IsKnocked ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
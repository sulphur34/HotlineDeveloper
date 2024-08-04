using BehaviorDesigner.Runtime.Tasks;
using Modules.DamageReceiverSystem.Enemies.EnemyBehavior.Variables;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
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
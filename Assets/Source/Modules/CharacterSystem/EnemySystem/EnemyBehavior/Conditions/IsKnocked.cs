using BehaviorDesigner.Runtime.Tasks;
using Modules.DamageSystem.Enemies.EnemyBehavior.Variables;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsKnocked")]
    public class IsKnocked : Conditional
    {
        public SharedDamageReceiver _damageReceiver;
        
        public override TaskStatus OnUpdate()
        {
            return _damageReceiver.Value.IsKnocked ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
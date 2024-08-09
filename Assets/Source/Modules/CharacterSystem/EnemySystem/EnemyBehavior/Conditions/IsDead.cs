using BehaviorDesigner.Runtime.Tasks;
using Modules.DamagerSystem;
using Modules.DamagerSystem.Enemies.EnemyBehavior.Variables;

namespace Modules.CharacterSystem.EnemiySystem.EnemyBehavior.Conditions
{
    [TaskCategory("CustomConditional")]
    [TaskName("IsDead")]
    public class IsDead : Conditional
    {
        public SharedDamageReceiver DamageReceiver;

        public override TaskStatus OnUpdate()
        {
            return DamageReceiver.Value.IsDead ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
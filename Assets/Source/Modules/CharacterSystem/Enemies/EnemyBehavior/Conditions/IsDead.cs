using BehaviorDesigner.Runtime.Tasks;
using Modules.DamageSystem;
using Modules.DamageSystem.Enemies.EnemyBehavior.Variables;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    public class IsDead : Conditional
    {
        public SharedDamageReceiver _damageReceiver;
        
        public override TaskStatus OnUpdate()
        {
            return _damageReceiver.Value.IsDead ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}
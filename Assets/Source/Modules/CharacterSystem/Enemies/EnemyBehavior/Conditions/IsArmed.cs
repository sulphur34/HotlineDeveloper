using BehaviorDesigner.Runtime.Tasks;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    public class IsArmed : Conditional
    {
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Success;
        }
    }
}
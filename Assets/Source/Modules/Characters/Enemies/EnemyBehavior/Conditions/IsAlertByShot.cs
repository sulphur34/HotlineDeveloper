using Pada1.BBCore;
using Pada1.BBCore.Framework;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [Condition("CustomBehaviour/IsAlertByShot")]
    public class IsAlertByShot : ConditionBase
    {
        public override bool Check()
        {
            // need to get sound detector component
            return true;
        }
    }
}
using Pada1.BBCore;
using Pada1.BBCore.Framework;

namespace Modules.Characters.Enemies.EnemyBehavior.Conditions
{
    [Condition("CustomBehaviour/IsArmedCondition")]
    internal class IsArmedCondition : ConditionBase
    {
        public override bool Check()
        {
            // need to get IsArmed(IsEquipped?) from IPicker component
            return true;
        }
    }
}
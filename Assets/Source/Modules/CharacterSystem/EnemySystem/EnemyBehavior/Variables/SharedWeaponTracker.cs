using BehaviorDesigner.Runtime;
using Modules.WeaponItemSystem;

namespace Modules.Characters.Enemies.EnemyBehavior.Variables
{
    public class SharedWeaponTracker : SharedVariable<WeaponTracker>
    {
        public static implicit operator SharedWeaponTracker(WeaponTracker value)
        {
            return new SharedWeaponTracker { Value = value };
        }
    }
}
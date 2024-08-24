using BehaviorDesigner.Runtime;
using Modules.WeaponsHandler;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior.Variables
{
    public class SharedPlayerWeaponHandler : SharedVariable<WeaponHandlerView>
    {
        public static implicit operator SharedPlayerWeaponHandler(WeaponHandlerView value)
        {
            return new SharedPlayerWeaponHandler { Value = value };
        }
    }
}
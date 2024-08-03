using BehaviorDesigner.Runtime;
using Modules.PlayerWeaponsHandler;

namespace Modules.CharacterSystem.Enemies.EnemyBehavior.Variables
{
    public class SharedPlayerWeaponHandler : SharedVariable<WeaponHandlerView>
    {
        public static implicit operator SharedPlayerWeaponHandler(WeaponHandlerView value)
        {
            return new SharedPlayerWeaponHandler { Value = value };
        }
    }
}
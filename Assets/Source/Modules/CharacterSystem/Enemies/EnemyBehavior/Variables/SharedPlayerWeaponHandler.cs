using BehaviorDesigner.Runtime;
using Modules.PlayerWeaponsHandler;

namespace Source.Modules.CharacterSystem.Enemies.EnemyBehavior.Variables
{
    public class SharedPlayerWeaponHandler : SharedVariable<PlayerWeaponHandler>
    {
        public static implicit operator SharedPlayerWeaponHandler(PlayerWeaponHandler value) { return new SharedPlayerWeaponHandler { Value = value }; }
    }
}
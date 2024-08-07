using Modules.InputSystem;
using Modules.Weapons.WeaponItemSystem;

namespace Modules.WeaponsHandler
{
    public class EnemyWeaponHandlerSetup : WeaponHandlerSetup
    {
        public void Initialize(AiInput aiInput, WeaponItemInitializer weaponItemInitializer)
        {
            base.Initialize(aiInput, aiInput, weaponItemInitializer);
        }
    }
}
using Modules.InputSystem;

namespace Modules.PlayerWeaponsHandler
{
    public class EnemyWeaponHandlerSetup : WeaponHandlerSetup
    {
        public void Initialize(AiInput aiInput)
        {
            WeaponHandler weaponHandler = new WeaponHandler(WeaponHandlerData, aiInput, aiInput);
            WeaponHandlerPresenter = new WeaponHandlerPresenter(weaponHandler, WeaponHandlerView);
        }
    }
}
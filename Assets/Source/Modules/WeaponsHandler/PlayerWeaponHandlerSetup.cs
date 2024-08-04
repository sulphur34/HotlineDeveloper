using Modules.InputSystem.Interfaces;
using VContainer;

namespace Modules.PlayerWeaponsHandler
{
    public class PlayerWeaponHandlerSetup : WeaponHandlerSetup
    {
        [Inject]
        public void Construct(IAttackInput attackInput, IPickInput pickInput)
        {
            WeaponHandler weaponHandler = new WeaponHandler(WeaponHandlerData, attackInput, pickInput);
            WeaponHandlerPresenter = new WeaponHandlerPresenter(weaponHandler, WeaponHandlerView);
        }
    }
}
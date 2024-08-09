using Modules.InputSystem.Interfaces;
using Modules.WeaponItemSystem;
using VContainer;

namespace Modules.WeaponsHandler
{
    public class PlayerWeaponHandlerSetup : WeaponHandlerSetup
    {
        [Inject]
        public void Construct(IAttackInput attackInput, IPickInput pickInput, WeaponItemInitializer weaponItemInitializer)
        {
            Initialize(attackInput, pickInput, weaponItemInitializer);
        }
    }
}
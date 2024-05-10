using Modules.InputSystem.Interfaces;
using VContainer;

namespace Modules.PlayerWeaponsHandler
{
    public class PlayerWeaponHandler : WeaponHandler
    {
        [Inject]
        public void Construct(IAttackInput shotInput, IPickInput weaponItemInput)
        {
            ShotInput = shotInput;
            WeaponItemInput = weaponItemInput;
            WeaponItemInput.PickReceived += OnWeaponItemInputReceived;
        }
    }
}
using Source.Modules.InputSystem.Interfaces;
using VContainer;

namespace Modules.PlayerWeaponsHandler
{
    public class PlayerWeaponHandler : WeaponHandler
    {
        [Inject]
        public void Construct(IAttackInput shotInput, IPickInput weaponItemInput)
        {
            _shotInput = shotInput;
            _weaponItemInput = weaponItemInput;
            _weaponItemInput.PickReceived += OnWeaponItemInputReceived;
        }
    }
}
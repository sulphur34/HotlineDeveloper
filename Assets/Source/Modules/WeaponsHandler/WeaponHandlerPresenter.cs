using Modules.Weapons.WeaponItemSystem;
using Modules.Weapons.WeaponTypeSystem;

namespace Modules.PlayerWeaponsHandler
{
    public class WeaponHandlerPresenter
    {
        private WeaponHandlerView _weaponHandlerView;
        private WeaponHandler _weaponHandler;
        public WeaponHandlerPresenter(WeaponHandler weaponHandler, WeaponHandlerView weaponHandlerView)
        {
            _weaponHandler = weaponHandler;
            _weaponHandler.WeaponPicked += OnWeaponPick;
            _weaponHandler.Attacked += OnWeaponAttack;
            _weaponHandlerView = weaponHandlerView;
            _weaponHandlerView.Initialize(_weaponHandler);
            _weaponHandlerView.Unequipped += _weaponHandler.UnequipWeaponItem;
        }

        private void OnWeaponPick(IWeaponInfo weaponItem)
        {
            _weaponHandlerView.OnPick(weaponItem);
        }

        private void OnWeaponAttack(WeaponType weaponType)
        {
            _weaponHandlerView.OnAttack(weaponType);
        }

        public void Dispose()
        {
            _weaponHandler.Attacked -= OnWeaponAttack;
            _weaponHandler.WeaponPicked -= OnWeaponPick;
            _weaponHandlerView.Unequipped -= _weaponHandler.UnequipWeaponItem;
        }
    }
}
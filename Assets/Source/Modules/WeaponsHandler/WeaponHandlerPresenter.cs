using Modules.DamageReceiverSystem;
using Modules.Weapons.WeaponItemSystem;
using Modules.WeaponTypes;

namespace Modules.WeaponsHandler
{
    public class WeaponHandlerPresenter
    {
        private readonly WeaponHandlerView _weaponHandlerView;
        private readonly WeaponHandler _weaponHandler;
        private readonly DamageReceiverView _damageReceiverView;

        public WeaponHandlerPresenter(WeaponHandler weaponHandler, WeaponHandlerView weaponHandlerView,
            DamageReceiverView damageReceiverView)
        {
            _weaponHandler = weaponHandler;
            _damageReceiverView = damageReceiverView;
            _weaponHandler.WeaponPicked += OnWeaponPick;
            _weaponHandler.Attacked += OnWeaponAttack;
            _weaponHandler.WeaponThrown += OnWeaponThrow;
            _weaponHandlerView = weaponHandlerView;
            _weaponHandlerView.Initialize();
            _damageReceiverView.FallenDown += OnFallDown;
        }

        private void OnFallDown()
        {
            _weaponHandlerView.UnequipWeapon(_weaponHandler);
            _weaponHandler.DisarmWeaponItem();
        }

        private void OnWeaponPick(IWeaponInfo weaponItem, IWeaponHandlerInfo weaponHandlerInfo)
        {
            _weaponHandlerView.OnPick(weaponItem, _weaponHandler);
        }

        private void OnWeaponThrow()
        {
            _weaponHandlerView.ClearHands();
        }

        private void OnWeaponAttack(WeaponType weaponType)
        {
            _weaponHandlerView.OnAttack(weaponType);
        }

        public void Dispose()
        {
            _weaponHandler.Attacked -= OnWeaponAttack;
            _weaponHandler.WeaponPicked -= OnWeaponPick;
            _weaponHandler.WeaponThrown -= OnWeaponThrow;
            _damageReceiverView.FallenDown -= OnFallDown;
        }
    }
}
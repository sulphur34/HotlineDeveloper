using Modules.DamageReceiverSystem;
using Modules.InputSystem.Interfaces;
using Modules.WeaponItemSystem;
using UnityEngine;

namespace Modules.WeaponsHandler
{
    public class WeaponHandlerSetup : MonoBehaviour
    {
        private WeaponHandlerPresenter _weaponHandlerPresenter;
        private WeaponHandler _weaponHandler;

        [field: SerializeField] protected WeaponHandlerData WeaponHandlerData { get; private set; }
        [field: SerializeField] protected WeaponHandlerView WeaponHandlerView { get; private set; }

        protected void Initialize(
            IAttackInput attackInput,
            IPickInput pickInput,
            WeaponItemInitializer weaponItemInitializer)
        {
            if (WeaponHandlerData.DefaultWeapon != null)
                weaponItemInitializer.InitializeWeapon(WeaponHandlerData.DefaultWeapon);

            _weaponHandler = new WeaponHandler(WeaponHandlerData, attackInput, pickInput);
            var damageReceiverView = GetComponent<DamageReceiverView>();
            _weaponHandlerPresenter = new WeaponHandlerPresenter(_weaponHandler, WeaponHandlerView, damageReceiverView);
        }

        private void OnDestroy()
        {
            _weaponHandler.Dispose();
            _weaponHandlerPresenter.Dispose();
        }
    }
}
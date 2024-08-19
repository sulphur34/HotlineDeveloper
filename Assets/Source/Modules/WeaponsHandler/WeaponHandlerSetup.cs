using Modules.DamagerSystem;
using Modules.InputSystem.Interfaces;
using Modules.WeaponItemSystem;
using UnityEngine;

namespace Modules.WeaponsHandler
{
    public class WeaponHandlerSetup : MonoBehaviour
    {
        [field: SerializeField] protected WeaponHandlerData WeaponHandlerData { get; private set; }
        [field: SerializeField] protected WeaponHandlerView WeaponHandlerView { get; private set; }

        private WeaponHandlerPresenter _weaponHandlerPresenter;

        protected void Initialize(
            IAttackInput attackInput,
            IPickInput pickInput,
            WeaponItemInitializer weaponItemInitializer)
        {
            if (WeaponHandlerData.DefaultWeapon != null)
                weaponItemInitializer.InitializeWeapon(WeaponHandlerData.DefaultWeapon);

            WeaponHandler weaponHandler = new (WeaponHandlerData, attackInput, pickInput);
            var damageReceiverView = GetComponent<DamageReceiverView>();
            _weaponHandlerPresenter = new WeaponHandlerPresenter(weaponHandler, WeaponHandlerView, damageReceiverView);
        }

        private void OnDestroy()
        {
            _weaponHandlerPresenter.Dispose();
        }
    }
}
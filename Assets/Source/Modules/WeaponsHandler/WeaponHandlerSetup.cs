using Modules.DamageReceiverSystem;
using Modules.InputSystem.Interfaces;
using Modules.Weapons.WeaponItemSystem;
using UnityEngine;

namespace Modules.WeaponsHandler
{
    public class WeaponHandlerSetup : MonoBehaviour
    {
        [SerializeField] protected WeaponHandlerData WeaponHandlerData;
        [SerializeField] protected WeaponHandlerView WeaponHandlerView;

        protected WeaponHandlerPresenter WeaponHandlerPresenter;
        
        protected void Initialize(IAttackInput attackInput, IPickInput pickInput,
            WeaponItemInitializer weaponItemInitializer)
        {
            weaponItemInitializer.InitializeWeapon(WeaponHandlerData.DefaultWeapon);
            WeaponHandler weaponHandler = new(WeaponHandlerData, attackInput, pickInput);
            var damageReceiverView = GetComponent<DamageReceiverView>();
            WeaponHandlerPresenter = new WeaponHandlerPresenter(weaponHandler, WeaponHandlerView, damageReceiverView);
        }

        private void OnDestroy()
        {
            WeaponHandlerPresenter.Dispose();
        }
    }
}
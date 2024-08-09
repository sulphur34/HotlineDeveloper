using Modules.DamageReceiverSystem;
using Modules.InputSystem.Interfaces;
using Modules.WeaponItemSystem;
using UnityEngine;

namespace Modules.WeaponsHandler
{
    public class WeaponHandlerSetup : MonoBehaviour
    {
        [SerializeField] protected WeaponHandlerData WeaponHandlerData;
        [SerializeField] protected WeaponHandlerView WeaponHandlerView;

        private WeaponHandlerPresenter _weaponHandlerPresenter;
        
        protected void Initialize(IAttackInput attackInput, IPickInput pickInput,
            WeaponItemInitializer weaponItemInitializer)
        {
            if (WeaponHandlerData.DefaultWeapon != null)
                weaponItemInitializer.InitializeWeapon(WeaponHandlerData.DefaultWeapon);
            
            WeaponHandler weaponHandler = new(WeaponHandlerData, attackInput, pickInput);
            var damageReceiverView = GetComponent<DamageReceiverView>();
            _weaponHandlerPresenter = new WeaponHandlerPresenter(weaponHandler, WeaponHandlerView, damageReceiverView);
        }

        private void OnDestroy()
        {
            _weaponHandlerPresenter.Dispose();
        }
    }
}
using Modules.Weapons.InputSystem;
using Modules.WeaponItemSystem;
using UnityEngine;
using VContainer;
 
namespace Modules.PlayerWeaponsHandler
{
    public class PlayerWeaponHandler : MonoBehaviour
    {
        [SerializeField] private Transform _container;

        private WeaponItem _weaponItem;
        private IShotInput _shotInput;
        private IWeaponItemInput _weaponItemInput;

        private bool _weaponItemHandled;

        private void OnDestroy()
        {
            if (_weaponItem != null && _weaponItem.Equipped)
                _shotInput.Received -= OnShotInputReceived;

            if (_weaponItemHandled)
                _weaponItemInput.Received -= OnWeaponItemInputReceived;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out WeaponItem weaponItem))
            {
                SetWeaponItem(weaponItem, true);
                _weaponItemInput.Received += OnWeaponItemInputReceived;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out WeaponItem _))
            {
                SetWeaponItem(null, false);
                _weaponItemInput.Received -= OnWeaponItemInputReceived;
            }
        }

        [Inject]
        public void Constructe(IShotInput shotInput, IWeaponItemInput weaponItemInput)
        {
            _shotInput = shotInput;
            _weaponItemInput = weaponItemInput;
        }

        private void SetWeaponItem(WeaponItem weaponItem, bool subscribed)
        {
            _weaponItem = weaponItem;
            _weaponItemHandled = subscribed;
        }

        private void OnWeaponItemInputReceived()
        {
            if (_weaponItem.Equipped)
            {
                _weaponItem.Throw();
                _shotInput.Received -= OnShotInputReceived;
            }
            else
            {
                _weaponItem.Equip(_container);
                _shotInput.Received += OnShotInputReceived;
            }
        }

        private void OnShotInputReceived()
        {
            _weaponItem.Attack();
        }
    }
}
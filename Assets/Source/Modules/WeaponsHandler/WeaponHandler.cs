using System;
using System.Linq;
using UnityEngine;
using Modules.Weapons.WeaponItemSystem;
using Source.Modules.InputSystem.Interfaces;

namespace Modules.PlayerWeaponsHandler
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _pickPoint;
        [SerializeField] private float _pickRadius;

        private WeaponItem _currentWeaponItem;
        protected IAttackInput _shotInput;
        protected IPickInput _weaponItemInput;

        public event Action<WeaponItem> WeaponPicked;

        public bool CurrentWeaponItemIsEmpty => _currentWeaponItem == null;

        private void OnDestroy()
        {
            _shotInput.AttackReceived -= OnShotInputReceived;
            _weaponItemInput.PickReceived -= OnWeaponItemInputReceived;
        }

        protected void OnWeaponItemInputReceived()
        {
            bool HasPickableWeapon = TryGetWeapon(out WeaponItem weaponItem);

            if (CurrentWeaponItemIsEmpty == false && _currentWeaponItem.IsEquipped)
            {
                _currentWeaponItem.Throw();
                _currentWeaponItem = null;
                _shotInput.AttackReceived -= OnShotInputReceived;
            }

            if (HasPickableWeapon)
            {
                EquipWeaponItem(weaponItem);
                _shotInput.AttackReceived += OnShotInputReceived;
            }
        }

        private void EquipWeaponItem(WeaponItem weaponItem)
        {
            _currentWeaponItem = weaponItem;
            _currentWeaponItem.Equip(_container);
            WeaponPicked?.Invoke(_currentWeaponItem);
        }

        private void OnShotInputReceived()
        {
            _currentWeaponItem.Attack();
        }

        private bool TryGetWeapon(out WeaponItem weaponItem)
        {
            weaponItem = Physics.OverlapSphere(_pickPoint.position, _pickRadius)
                .Where(collider => IsColliderAvailableWeapon(collider))
                .OrderBy(collider => (collider.transform.position - _pickPoint.position).magnitude)
                .FirstOrDefault()
                ?.GetComponent<WeaponItem>();

            return weaponItem != null;
        }

        private bool IsColliderAvailableWeapon(Collider collider)
        {
            WeaponItem weaponItem = collider.GetComponent<WeaponItem>();

            if (weaponItem == null || weaponItem == _currentWeaponItem || weaponItem.IsEquipped == true)
                return false;

            return true;
        }
    }
}
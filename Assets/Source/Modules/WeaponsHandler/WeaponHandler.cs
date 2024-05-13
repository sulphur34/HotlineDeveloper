using System;
using System.Linq;
using UnityEngine;
using Modules.Weapons.WeaponItemSystem;
using Modules.Weapons.WeaponTypeSystem;
using Modules.InputSystem.Interfaces;

namespace Modules.PlayerWeaponsHandler
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private WeaponItem _defaultWeapon;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _pickPoint;
        [SerializeField] private float _pickRadius;

        protected IAttackInput ShotInput;
        protected IPickInput WeaponItemInput;
        private WeaponItem _currentWeaponItem;

        public event Action<WeaponItem> WeaponPicked;
        public event Action RangeWeaponFired;

        public bool CurrentWeaponItemIsEmpty => _currentWeaponItem == null || _currentWeaponItem == _defaultWeapon;
        public WeaponType CurrentWeaponType => _currentWeaponItem.WeaponType;

        private void Start()
        {
            EquipWeaponItem(_defaultWeapon);
        }

        private void OnDestroy()
        {
            ShotInput.AttackReceived -= OnShotInputReceived;
            WeaponItemInput.PickReceived -= OnWeaponItemInputReceived;
        }

        public void UnequipWeaponItem()
        {
            if (_currentWeaponItem == null || _currentWeaponItem == _defaultWeapon)
                return;
            
            _currentWeaponItem.Unequip();
            _currentWeaponItem.RangeFired -= OnRangeFire;
            _currentWeaponItem = null;
            ShotInput.AttackReceived -= OnShotInputReceived;

            if (_defaultWeapon != null)
                _defaultWeapon.RangeFired += OnRangeFire;
            
        }

        protected void OnWeaponItemInputReceived()
        {
            bool HasPickableWeapon = TryGetWeapon(out WeaponItem weaponItem);

            if (CurrentWeaponItemIsEmpty == false && _currentWeaponItem.IsEquipped)
            {
                _currentWeaponItem.Throw();
                _currentWeaponItem.RangeFired -= OnRangeFire;
                _currentWeaponItem = _defaultWeapon;
                ShotInput.AttackReceived -= OnShotInputReceived;
            }

            if (HasPickableWeapon)
            {
                EquipWeaponItem(weaponItem);
            }
        }

        private void EquipWeaponItem(WeaponItem weaponItem)
        {
            if(weaponItem == null)
                return;
            
            _currentWeaponItem = weaponItem;
            _currentWeaponItem.RangeFired += OnRangeFire;
            _currentWeaponItem.Equip(_container);
            WeaponPicked?.Invoke(_currentWeaponItem);
            ShotInput.AttackReceived += OnShotInputReceived;
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

        private void OnRangeFire()
        {
            RangeWeaponFired?.Invoke();
        }
    }
}
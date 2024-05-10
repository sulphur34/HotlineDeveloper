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
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _pickPoint;
        [SerializeField] private float _pickRadius;

        private WeaponItem _currentWeaponItem;
        protected IAttackInput ShotInput;
        protected IPickInput WeaponItemInput;

        public event Action<WeaponItem> WeaponPicked;
        public event Action RangeWeaponFired;

        public bool CurrentWeaponItemIsEmpty => _currentWeaponItem == null;
        public WeaponType CurrentWeaponType => _currentWeaponItem.WeaponType;

        private void OnDestroy()
        {
            ShotInput.AttackReceived -= OnShotInputReceived;
            WeaponItemInput.PickReceived -= OnWeaponItemInputReceived;
        }

        public void LooseWeapon()
        {
            if (_currentWeaponItem == null)
                return;
            
            _currentWeaponItem.LooseWeapon();
            _currentWeaponItem = null;
            ShotInput.AttackReceived -= OnShotInputReceived;
        }

        protected void OnWeaponItemInputReceived()
        {
            bool HasPickableWeapon = TryGetWeapon(out WeaponItem weaponItem);

            if (CurrentWeaponItemIsEmpty == false && _currentWeaponItem.IsEquipped)
            {
                _currentWeaponItem.Throw();
                _currentWeaponItem.RangeFired -= OnRangeFire;
                _currentWeaponItem = null;
                ShotInput.AttackReceived -= OnShotInputReceived;
            }

            if (HasPickableWeapon)
            {
                EquipWeaponItem(weaponItem);
                ShotInput.AttackReceived += OnShotInputReceived;
            }
        }

        private void EquipWeaponItem(WeaponItem weaponItem)
        {
            _currentWeaponItem = weaponItem;
            _currentWeaponItem.RangeFired += OnRangeFire;
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

        private void OnRangeFire()
        {
            RangeWeaponFired?.Invoke();
        }
    }
}
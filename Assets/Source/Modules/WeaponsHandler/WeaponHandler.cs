using System;
using System.Linq;
using Modules.DamageReceiverSystem;
using UnityEngine;
using Modules.Weapons.WeaponItemSystem;
using Modules.Weapons.WeaponTypeSystem;
using Modules.InputSystem.Interfaces;

namespace Modules.PlayerWeaponsHandler
{
    public class WeaponHandler : IWeaponHandlerInfo
    {
        private readonly float _lookHeight = 1.5f;
        
        protected IAttackInput _attackInput;
        protected IPickInput _pickInput;
        private WeaponItem _currentWeaponItem;
        private WeaponItem _defaultWeaponItem;
        private WeaponStrategy _weaponStrategy;
        private WeaponStrategy _thrownWeaponStrategy;
        private Transform _container;
        private Transform _pickPoint;
        private float _pickRadius;

        public event Action<IWeaponInfo> WeaponPicked;
        public event Action WeaponThrown;
        public event Action<WeaponType> Attacked;

        public bool CurrentWeaponItemIsEmpty => _currentWeaponItem == null || _currentWeaponItem == _defaultWeaponItem;
        public WeaponType CurrentWeaponType => _currentWeaponItem.WeaponType;
        
        public WeaponHandler(WeaponHandlerData weaponHandlerData, IAttackInput attackInput, IPickInput pickInput)
        {
            _pickRadius = weaponHandlerData.PickRadius;
            _pickPoint = weaponHandlerData.PickPoint;
            _container = weaponHandlerData.Container;
            _defaultWeaponItem = weaponHandlerData.DefaultWeapon;
            _attackInput = attackInput;
            _pickInput = pickInput;
            _pickInput.PickReceived += OnPickInputReceived;
            EquipWeaponItem(_defaultWeaponItem);              
        }

        public void DisarmWeaponItem()
        {
            if (_currentWeaponItem == null || _currentWeaponItem == _defaultWeaponItem)
                return;
            
            _weaponStrategy?.ClearOwner();
            _currentWeaponItem.Unequip();
            _currentWeaponItem.Attacked -= OnAttack;
            _currentWeaponItem = _defaultWeaponItem;
            _attackInput.AttackReceived -= OnAttackInputReceived;

            if (_defaultWeaponItem != null)
                _defaultWeaponItem.Attacked += OnAttack;
        }

        private void OnPickInputReceived()
        {
            bool HasPickableWeapon = TryGetWeapon(out WeaponItem weaponItem);

            if (CurrentWeaponItemIsEmpty == false && _currentWeaponItem.IsEquipped)
            {
                WeaponItem weapon = _currentWeaponItem;
                _currentWeaponItem.Attacked -= OnAttack;
                WeaponThrown?.Invoke();
                _thrownWeaponStrategy = _weaponStrategy;
                _currentWeaponItem.Throw(ClearOwner);
                _attackInput.AttackReceived -= OnAttackInputReceived;
            }

            EquipWeaponItem(HasPickableWeapon ? weaponItem : _defaultWeaponItem);
        }

        private void ClearOwner()
        {
            _thrownWeaponStrategy?.ClearOwner();
        }

        private void EquipWeaponItem(WeaponItem weaponItem)
        {
            if(weaponItem == null)
                return;
            
            _currentWeaponItem = weaponItem;
            _weaponStrategy = _currentWeaponItem.GetComponent<WeaponStrategy>();
            _weaponStrategy.Equip(_container);
            _currentWeaponItem.Attacked += OnAttack;
            _currentWeaponItem.Equip(_container);
            WeaponPicked?.Invoke(_currentWeaponItem);
            _attackInput.AttackReceived += OnAttackInputReceived;
        }

        private void OnAttackInputReceived()
        {
            _currentWeaponItem.Attack();
        }

        private bool TryGetWeapon(out WeaponItem weaponItem)
        {
            weaponItem = Physics.OverlapSphere(_pickPoint.position, _pickRadius)
                .Where(IsAvailableWeapon)
                .Where(IsNoObstacles)
                .OrderBy(collider => (collider.transform.position - _pickPoint.position).magnitude)
                .FirstOrDefault()
                ?.GetComponent<WeaponItem>();

            return weaponItem != null;
        }
        
        private bool IsAvailableWeapon(Collider collider)
        {
            WeaponItem weaponItem = collider.GetComponent<WeaponItem>();

            if (weaponItem == null || weaponItem == _currentWeaponItem || weaponItem.IsEquipped == true)
                return false;

            return true;
        }

        private bool IsNoObstacles(Collider collider)
        {
            Vector3 alignedPosition = _pickPoint.position;
            alignedPosition.y += _lookHeight;
            if (!Physics.Linecast(alignedPosition, collider.transform.position, out RaycastHit hit))
                return false;
            
            return hit.collider.TryGetComponent(out WeaponItem weaponItem);
        }

        private void OnAttack(WeaponType weaponType)
        {
            WeaponType currentType = weaponType;

            if (_currentWeaponItem == _defaultWeaponItem)
                currentType =  WeaponType.BareHands;
            
            Attacked?.Invoke(currentType);
        }
    }
}
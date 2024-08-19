using System;
using Modules.InputSystem.Interfaces;
using Modules.WeaponItemSystem;
using Modules.WeaponsTypes;
using UnityEngine;

namespace Modules.WeaponsHandler
{
    public class WeaponHandler : IWeaponHandlerInfo, IDisposable
    {
        private readonly Transform _container;
        private readonly WeaponItem _defaultWeaponItem;
        private readonly IAttackInput _attackInput;
        private readonly Picker _picker;

        private WeaponItem _currentWeaponItem;
        private readonly IPickInput _pickInput;

        public event Action<IWeaponInfo, IWeaponHandlerInfo> WeaponPicked;

        public event Action WeaponThrown;

        public event Action<WeaponType> Attacked;

        public WeaponHandler(WeaponHandlerData weaponHandlerData, IAttackInput attackInput, IPickInput pickInput)
        {
            _container = weaponHandlerData.Container;
            _defaultWeaponItem = weaponHandlerData.DefaultWeapon;
            _attackInput = attackInput;
            EquipWeaponItem(_defaultWeaponItem);

            _picker = new Picker(
                _currentWeaponItem,
                weaponHandlerData.PickPoint,
                weaponHandlerData.PickRadius,
                weaponHandlerData.LookHeight);

            _pickInput = pickInput;
            _pickInput.PickReceived += OnPickInputReceived;
        }

        public bool IsCurrentWeaponItemEmpty => _currentWeaponItem == null || _currentWeaponItem == _defaultWeaponItem;

        public WeaponType CurrentWeaponType => _currentWeaponItem.WeaponType;

        public void Dispose()
        {
            if (_pickInput != null)
                _pickInput.PickReceived -= OnPickInputReceived;
        }

        public void DisarmWeaponItem()
        {
            if (_currentWeaponItem == null || _currentWeaponItem == _defaultWeaponItem)
                return;

            _currentWeaponItem.Unequip();
            UnsubscribeWeapon();
            _currentWeaponItem = _defaultWeaponItem;

            if (_defaultWeaponItem != null)
                _defaultWeaponItem.Attacked += OnAttack;
        }

        private void OnPickInputReceived()
        {
            bool hasPickableWeapon = _picker.TryGetWeapon(out WeaponItem weaponItem);

            if (IsCurrentWeaponItemEmpty == false && _currentWeaponItem.IsEquipped)
                ThrowWeapon();

            EquipWeaponItem(hasPickableWeapon ? weaponItem : _defaultWeaponItem);
        }

        private void ThrowWeapon()
        {
            UnsubscribeWeapon();
            WeaponThrown?.Invoke();
            _currentWeaponItem.Throw();
        }

        private void UnsubscribeWeapon()
        {
            _currentWeaponItem.Attacked -= OnAttack;
            _attackInput.AttackReceived -= OnAttackInputReceived;
        }

        private void EquipWeaponItem(WeaponItem weaponItem)
        {
            if (weaponItem == null)
                return;

            _currentWeaponItem = weaponItem;
            _currentWeaponItem.Attacked += OnAttack;
            _currentWeaponItem.Equip(_container);
            WeaponPicked?.Invoke(_currentWeaponItem, this);
            _attackInput.AttackReceived += OnAttackInputReceived;
        }

        private void OnAttackInputReceived()
        {
            _currentWeaponItem.Attack();
        }

        private void OnAttack(WeaponType weaponType)
        {
            WeaponType currentType = weaponType;

            if (_currentWeaponItem == _defaultWeaponItem)
                currentType = WeaponType.BareHands;

            Attacked?.Invoke(currentType);
        }
    }
}
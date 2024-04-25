using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using Modules.Weapons.WeaponItemSystem;
using Source.Modules.InputSystem.Interfaces;

namespace Modules.PlayerWeaponsHandler
{
    public class PlayerWeaponHandler : MonoBehaviour
    {
        private readonly List<WeaponItem> _lastWeaponsInRadius = new List<WeaponItem>();

        [SerializeField] private Transform _container;

        private WeaponItem _currentWeaponItem;
        private IAttackInput _shotInput;
        private IPickInput _weaponItemInput;

        public event Action<WeaponItem> WeaponPicked;

        private WeaponItem LastWeaponInRadius => HasWeaponItemsInRaduis ? _lastWeaponsInRadius[^1] : null;

        private bool HasWeaponItemsInRaduis => _lastWeaponsInRadius.Count > 0;

        private bool CurrentWeaponItemIsEmpty => _currentWeaponItem == null;

        private void OnDestroy()
        {
            if (HasWeaponItemsInRaduis && LastWeaponInRadius.Equipped)
                _shotInput.AttackReceived -= OnShotInputReceived;

            _weaponItemInput.PickReceived -= OnWeaponItemInputReceived;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out WeaponItem weaponItem))
                _lastWeaponsInRadius.Add(weaponItem);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out WeaponItem weaponItem))
                _lastWeaponsInRadius.Remove(weaponItem);
        }

        [Inject]
        public void Construct(IAttackInput shotInput, IPickInput weaponItemInput)
        {
            _shotInput = shotInput;
            _weaponItemInput = weaponItemInput;
            _weaponItemInput.PickReceived += OnWeaponItemInputReceived;
        }

        private void OnWeaponItemInputReceived()
        {
            if (CurrentWeaponItemIsEmpty && HasWeaponItemsInRaduis == false)
                return;

            if (CurrentWeaponItemIsEmpty == false && _currentWeaponItem.Equipped)
            {
                _currentWeaponItem.Throw();
                _lastWeaponsInRadius.Remove(_currentWeaponItem);

                if (HasWeaponItemsInRaduis)
                {
                    EquipWeaponItem();
                    return;
                }

                _currentWeaponItem = null;
                _shotInput.AttackReceived -= OnShotInputReceived;
            }
            else
            {
                EquipWeaponItem();
                _shotInput.AttackReceived += OnShotInputReceived;
            }
        }

        private void EquipWeaponItem()
        {
            _currentWeaponItem = LastWeaponInRadius;
            _currentWeaponItem.Equip(_container);
            WeaponPicked?.Invoke(_currentWeaponItem);
            _lastWeaponsInRadius.Remove(_currentWeaponItem);
        }

        private void OnShotInputReceived()
        {
            _currentWeaponItem.Attack();
        }
    }
}
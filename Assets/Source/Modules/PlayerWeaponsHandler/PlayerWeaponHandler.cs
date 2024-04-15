using Modules.Weapons.InputSystem;
using Modules.WeaponItemSystem;
using UnityEngine;
using VContainer;
using System.Collections.Generic;

namespace Modules.PlayerWeaponsHandler
{
    public class PlayerWeaponHandler : MonoBehaviour
    {
        [SerializeField] private Transform _container;

        private WeaponItem _currentWeaponItem;
        private IShotInput _shotInput;
        private IWeaponItemInput _weaponItemInput;

        private readonly List<WeaponItem> _lastWeaponsInRadius = new List<WeaponItem>();

        private WeaponItem LastWeaponInRadius => _lastWeaponsInRadius[^1];
        private bool HasWeaponItemsInRaduis => _lastWeaponsInRadius.Count > 0;

        private void Start()
        {
            _weaponItemInput.Received += OnWeaponItemInputReceived;
        }

        private void OnDestroy()
        {
            if (HasWeaponItemsInRaduis && LastWeaponInRadius.Equipped)
                _shotInput.Received -= OnShotInputReceived;

            _weaponItemInput.Received -= OnWeaponItemInputReceived;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out WeaponItem weaponItem))
                _lastWeaponsInRadius.Add(weaponItem);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out WeaponItem _))
                _lastWeaponsInRadius.Remove(LastWeaponInRadius);
        }

        [Inject]
        public void Constructe(IShotInput shotInput, IWeaponItemInput weaponItemInput)
        {
            _shotInput = shotInput;
            _weaponItemInput = weaponItemInput;
        }

        private void OnWeaponItemInputReceived()
        {
            if (HasWeaponItemsInRaduis == false)
                return;

            if (_currentWeaponItem.Equipped)
            {
                _currentWeaponItem.Throw();

                if (_lastWeaponsInRadius.Count > 0)
                {
                    _currentWeaponItem = LastWeaponInRadius;
                    _currentWeaponItem.Equip(_container);
                    _lastWeaponsInRadius.Remove(_currentWeaponItem);
                    return;
                }

                _shotInput.Received -= OnShotInputReceived;
            }
            else
            {
                _currentWeaponItem = LastWeaponInRadius;
                _currentWeaponItem.Equip(_container);
                _lastWeaponsInRadius.Remove(_currentWeaponItem);
                _shotInput.Received += OnShotInputReceived;
            }
        }

        private void OnShotInputReceived()
        {
            _currentWeaponItem.Attack();
        }
    }
}
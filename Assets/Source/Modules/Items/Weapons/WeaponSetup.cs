using Modules.Items.Weapons.Ammunition;
using Modules.Items.Weapons.InputSystem;
using UnityEngine;
using VContainer;

namespace Modules.Items.Weapons
{
    public class WeaponSetup : MonoBehaviour
    {
        [SerializeField] private ShotStrategy _shotStrategy;
        [SerializeField] private WeaponAmmunitionView _weaponAmmunition;

        private WeaponPresenter _presenter;

        private void OnDestroy()
        {
            _presenter.Dispose();
        }

        [Inject]
        private void Construct(WeaponConfigFabric fabric, IShotInput shotInput)
        {
            WeaponConfig config = fabric.Get(_shotStrategy);
            _shotStrategy.Init(config);
            Weapon weapon = new Weapon(_shotStrategy, this, config, _weaponAmmunition);
            _presenter = new WeaponPresenter(weapon, shotInput);
        }
    }
}
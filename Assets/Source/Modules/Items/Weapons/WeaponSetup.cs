using Modules.BulletPoolSystem;
using Modules.Items.Weapons.Ammunition;
using Modules.Items.Weapons.InputSystem;
using UnityEngine;
using VContainer;

namespace Modules.Items.Weapons
{
    public class WeaponSetup : MonoBehaviour
    {
        [SerializeField] private ShotStrategy _shotStrategy;

        private WeaponPresenter _weaponPresenter;
        private WeaponAmmunitionPresenter _ammunitionPresenter;
        private BulletPool _bulletPool;

        private void OnDestroy()
        {
            _ammunitionPresenter.Dispose();
            _weaponPresenter.Dispose();
            _bulletPool.Dispose();
        }

        [Inject]
        private void Construct(WeaponConfigFactory factory, IShotInput shotInput, WeaponAmmunitionView ammunitionView)
        {
            WeaponConfig config = factory.Get(_shotStrategy);
            _bulletPool = new BulletPool(config.BulletPrefab, transform);
            _shotStrategy.Init(config, _bulletPool);

            WeaponAmmunition ammunition = new WeaponAmmunition(config.BulletsCount);
            _ammunitionPresenter = new WeaponAmmunitionPresenter(ammunition, ammunitionView);

            Weapon weapon = new Weapon(_shotStrategy, this, config.RechargeTime, ammunition);
            _weaponPresenter = new WeaponPresenter(weapon, shotInput);
        }
    }
}
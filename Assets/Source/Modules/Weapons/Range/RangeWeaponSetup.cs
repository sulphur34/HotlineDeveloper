using Modules.BulletPoolSystem;
using Modules.Weapons.Ammunition;
using Modules.Weapons.WeaponItemSystem;
using UnityEngine;
using VContainer;

namespace Modules.Weapons.Range
{
    [RequireComponent(typeof(WeaponAmmunitionView))]
    public class RangeWeaponSetup : WeaponSetup
    {
        [SerializeField] private ShotStrategy _shotStrategy;

        private WeaponAmmunitionPresenter _ammunitionPresenter;
        private BulletPool _bulletPool;

        private void OnDestroy()
        {
            _ammunitionPresenter.Dispose();
            _bulletPool.Dispose();
        }

        [Inject]
        private void Construct(RangeWeaponConfigFactory factory)
        {
            WeaponAmmunitionView ammunitionView = GetComponent<WeaponAmmunitionView>();
            WeaponItem weaponItem = GetComponent<WeaponItem>();
            RangeWeaponConfig config = factory.Get(_shotStrategy);
            _bulletPool = new BulletPool(config.BulletPrefab);
            _shotStrategy.Init(config, _bulletPool);

            WeaponAmmunition ammunition = new WeaponAmmunition(config.BulletsCount);
            _ammunitionPresenter = new WeaponAmmunitionPresenter(ammunition, ammunitionView);

            RangeAttackModule attackModule = new RangeAttackModule(_shotStrategy, ammunition);
            Init(config.RechargeTime, attackModule);
        }
    }
}
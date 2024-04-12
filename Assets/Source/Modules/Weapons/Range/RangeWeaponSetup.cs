using Modules.BulletPoolSystem;
using Modules.Weapons.Ammunition;
using UnityEngine;
using VContainer;

namespace Modules.Weapons.Range
{
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
        private void Construct(RangeWeaponConfigFactory factory, WeaponAmmunitionView ammunitionView)
        {
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
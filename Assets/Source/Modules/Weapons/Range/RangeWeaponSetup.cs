using Modules.BulletSystem;
using Modules.Weapons.Ammunition;
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
        private RangeWeaponConfig _config;

        private void OnDestroy()
        {
            _ammunitionPresenter.Dispose();
            _bulletPool.Dispose();
        }

        public void SetShotStrategy(RangeWeaponConfigFactory factory)
        {
            _config = factory.Get(_shotStrategy);
            _bulletPool = new BulletPool(_config.BulletPrefab);
            _shotStrategy.Init(_config, _bulletPool);
        }

        public override void Initialize()
        {
            WeaponAmmunitionView ammunitionView = GetComponent<WeaponAmmunitionView>();
            WeaponAmmunition ammunition = new WeaponAmmunition(_config.BulletsCount);
            _ammunitionPresenter = new WeaponAmmunitionPresenter(ammunition, ammunitionView);
            RangeAttackModule attackModule = new RangeAttackModule(_shotStrategy, ammunition);
            SetWeapon(_config.RechargeTime, attackModule);
        }
    }
}
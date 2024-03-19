using System;
using Modules.CoroutineStarterSystem;
using Modules.Items.Weapons.Ammunition;
using Modules.Items.Weapons.InputSystem;
using VContainer;
using Object = UnityEngine.Object;

namespace Modules.Items.Weapons
{
    public class Weapon : IDisposable
    {
        private readonly WeaponConfig _config;
        private readonly IShotInput _input;
        private readonly CoroutineStarter _coroutineStarter;
        private readonly WeaponRechargeTime _rechargeTime;
        private readonly WeaponAmmunition _ammunition;
        private readonly WeaponAmmunitionPresenter _ammunitionPresenter;

        [Inject]
        internal Weapon(WeaponConfigFabric fabric, IShotInput input, CoroutineStarter coroutineStarter, IWeaponAmmunitionView ammunitionView)
        { 
            _config = fabric.Get(this);
            _input = input;
            _coroutineStarter = coroutineStarter;
            _rechargeTime = new WeaponRechargeTime(_config.RechargeTime);
            _ammunition = new WeaponAmmunition(_config.BulletsCount);
            _ammunitionPresenter = new WeaponAmmunitionPresenter(_ammunition, ammunitionView);

            _input.Received += OnReceived;
        }

        public void Dispose()
        {
            _input.Received -= OnReceived;
            _ammunitionPresenter.Dispose();
        }

        private void Shot()
        {
            Bullet bullet = Object.Instantiate(_config.BulletPrefab);
            bullet.Init(_config.BulletSpeed);

            _ammunition.Remove();
            _rechargeTime.Discharge();
            _coroutineStarter.StartRoutine(_rechargeTime.WaitRecharged());
        }

        private void OnReceived()
        {
            if (_ammunition.Count > 0 && _rechargeTime.Recharged)
                Shot();
        }
    }
}
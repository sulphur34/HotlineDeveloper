using System;
using Modules.CoroutineStarterSystem;
using VContainer;
using Object = UnityEngine.Object;

namespace Modules.Items.Weapons
{
    public class Weapon : IDisposable
    {
        private readonly WeaponConfig _weaponConfig;
        private readonly ShotDesktopInput _input;
        private readonly WeaponRechargeTime _weaponRechargeTime;
        private readonly CoroutineStarter _coroutineStarter;

        [Inject]
        internal Weapon(WeaponConfigFabric fabric, ShotDesktopInput input, CoroutineStarter coroutineStarter)
        {
            _weaponConfig = fabric.Get(this);
            _input = input;
            _coroutineStarter = coroutineStarter;
            _weaponRechargeTime = new WeaponRechargeTime(_weaponConfig.RechargeTime);
            _input.Received += OnReceived;
        }

        public void Dispose()
        {
            _input.Received -= OnReceived;
        }

        private void Shot()
        {
            Bullet bullet = Object.Instantiate(_weaponConfig.BulletPrefab);
            bullet.Init(_weaponConfig.BulletSpeed);

            _weaponRechargeTime.Discharge();
            _coroutineStarter.StartRoutine(_weaponRechargeTime.WaitRecharged());
        }

        private void OnReceived()
        {
            if (_weaponRechargeTime.Recharged)
                Shot();
        }
    }
}
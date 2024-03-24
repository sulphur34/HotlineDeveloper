using System;
using Modules.Items.Weapons.Ammunition;
using UnityEngine;

namespace Modules.Items.Weapons
{
    internal class Weapon : IDisposable
    {
        private readonly ShotStrategy _shotStrategy;
        private readonly MonoBehaviour _coroutineStarter;
        private readonly WeaponRechargeTime _rechargeTime;
        private readonly WeaponAmmunition _ammunition;
        private readonly WeaponAmmunitionPresenter _ammunitionPresenter;

        internal Weapon(ShotStrategy shotStrategy, MonoBehaviour coroutineStarter, WeaponConfig config, WeaponAmmunitionView ammunitionView)
        {
            _shotStrategy = shotStrategy;
            _coroutineStarter = coroutineStarter;
            _rechargeTime = new WeaponRechargeTime(config.RechargeTime);
            _ammunition = new WeaponAmmunition(config.BulletsCount);
            _ammunitionPresenter = new WeaponAmmunitionPresenter(_ammunition, ammunitionView);
        }

        public void Dispose()
        {
            _ammunitionPresenter.Dispose();
        }

        internal void Shot()
        {
            if (_ammunition.Count > 0 && _rechargeTime.Recharged)
            {
                _shotStrategy.Shot();
                _ammunition.Remove();
                _rechargeTime.Discharge();
                _coroutineStarter.StartCoroutine(_rechargeTime.WaitRecharged());
            }
        }
    }
}
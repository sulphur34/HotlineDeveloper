using System;
using Modules.Items.Weapons.Ammunition;
using UnityEngine;

namespace Modules.Items.Weapons
{
    internal class Weapon
    {
        private readonly ShotStrategy _shotStrategy;
        private readonly MonoBehaviour _coroutineStarter;
        private readonly WeaponRechargeTime _rechargeTime;
        private readonly WeaponAmmunition _ammunition;

        internal Weapon(ShotStrategy shotStrategy, MonoBehaviour coroutineStarter, float rechargeTime, WeaponAmmunition ammunition)
        {
            _shotStrategy = shotStrategy;
            _coroutineStarter = coroutineStarter;
            _rechargeTime = new WeaponRechargeTime(rechargeTime);
            _ammunition = ammunition;
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
using System;
using UnityEngine;

namespace Modules.Items.Weapons
{
    internal class Weapon
    {
        private readonly MonoBehaviour _coroutineStarter;
        private readonly WeaponRechargeTime _rechargeTime;
        private readonly IAttackModule _attackModule;

        internal Weapon(MonoBehaviour coroutineStarter, WeaponRechargeTime rechargeTime, IAttackModule attackModule)
        {
            _coroutineStarter = coroutineStarter;
            _rechargeTime = rechargeTime;
            _attackModule = attackModule;
        }

        internal event Action Attacked;

        internal void Attack()
        {
            if (_rechargeTime.Recharged)
            {
                _attackModule.Attack();
                _rechargeTime.Discharge();
                _coroutineStarter.StartCoroutine(_rechargeTime.WaitRecharged());
                Attacked?.Invoke();
            }
        }
    }
}
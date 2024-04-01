using System;
using System.Collections;
using UnityEngine;

namespace Modules.Items.Weapons
{
    internal abstract class Weapon : IAttacker
    {
        private readonly MonoBehaviour _coroutineStarter;
        private readonly WeaponRechargeTime _rechargeTime;

        internal Weapon(MonoBehaviour coroutineStarter, float rechargeTime)
        {
            _coroutineStarter = coroutineStarter;
            _rechargeTime = new WeaponRechargeTime(rechargeTime);
        }

        public event Action Attacked;

        protected abstract bool CanAttack { get; }

        public void Attack()
        {
            if (CanAttack && _rechargeTime.Recharged)
            {
                RealizeAttack();
                _rechargeTime.Discharge();
                _coroutineStarter.StartCoroutine(_rechargeTime.WaitRecharged());
                Attacked?.Invoke();
            }
        }

        protected abstract void RealizeAttack();

        protected void StartCoroutine(IEnumerator routine)
        {
            _coroutineStarter.StartCoroutine(routine);
        }
    }
}
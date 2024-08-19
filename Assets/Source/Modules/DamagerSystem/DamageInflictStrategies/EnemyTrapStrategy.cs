using System;
using Modules.DamageReceiverSystem;
using UnityEngine;

namespace Modules.DamagerSystem.DamageInflictStrategies
{
    internal class EnemyTrapStrategy : WeaponStrategy
    {
        [SerializeField] private DamageReceiverView _damageReceiverView;

        internal event Action EnemyDamaged;

        public override void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData)
        {
            if (damageReceiverView == _damageReceiverView)
                return;

            damageReceiverView.Receive(damageData);
            EnemyDamaged?.Invoke();
        }
    }
}
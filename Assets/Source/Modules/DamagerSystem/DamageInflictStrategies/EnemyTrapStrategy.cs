using System;
using UnityEngine;

namespace Modules.DamageReceiverSystem
{
    public class EnemyTrapStrategy : WeaponStrategy
    {
        [SerializeField] private DamageReceiverView _damageReceiverView;

        public event Action EnemyDamaged;
        
        public override void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData)
        {
            if (damageReceiverView == _damageReceiverView)
                return;
            
            damageReceiverView.Receive(damageData);
            EnemyDamaged?.Invoke();
        }
    }
}
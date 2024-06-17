using UnityEngine;

namespace Modules.DamageSystem
{
    public class EnemyTrapStrategy : WeaponStrategy
    {
        [SerializeField] private DamageReceiverView _damageReceiverView;
        public override void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData)
        {
            if (damageReceiverView == _damageReceiverView)
                return;
            
            damageReceiverView.Receive(damageData);
        }
    }
}
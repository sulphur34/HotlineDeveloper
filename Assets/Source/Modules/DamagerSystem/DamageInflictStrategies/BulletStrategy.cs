using UnityEngine;

namespace Modules.DamagerSystem
{
    internal class BulletStrategy : MonoBehaviour, IDamageInflictStrategy
    {
        public void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData)
        {
            damageReceiverView.Receive(damageData);
        }
    }
}
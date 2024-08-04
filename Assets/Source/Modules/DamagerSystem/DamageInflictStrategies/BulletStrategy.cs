using UnityEngine;

namespace Modules.DamageReceiverSystem
{
    public class BulletStrategy : MonoBehaviour, IDamageInflictStrategy
    {
        public void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData)
        {
            damageReceiverView.Receive(damageData);
        }
    }
}
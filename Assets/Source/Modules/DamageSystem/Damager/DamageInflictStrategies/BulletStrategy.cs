using UnityEngine;

namespace Modules.DamageSystem
{
    public class BulletStrategy : MonoBehaviour, IDamageInflictStrategy
    {
        public void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData)
        {
            damageReceiverView.Receive(damageData);
        }
    }
}
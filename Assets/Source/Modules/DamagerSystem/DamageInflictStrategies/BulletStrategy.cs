using Modules.DamageReceiverSystem;
using UnityEngine;

namespace Modules.DamagerSystem.DamageInflictStrategies
{
    internal class BulletStrategy : MonoBehaviour, IDamageInflictStrategy
    {
        public void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData)
        {
            damageReceiverView.Receive(damageData);
        }
    }
}
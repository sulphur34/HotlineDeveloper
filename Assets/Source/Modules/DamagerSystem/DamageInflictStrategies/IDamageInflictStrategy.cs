using UnityEngine;

namespace Modules.DamageReceiverSystem
{
    public interface IDamageInflictStrategy
    {
        void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData);
    }
}
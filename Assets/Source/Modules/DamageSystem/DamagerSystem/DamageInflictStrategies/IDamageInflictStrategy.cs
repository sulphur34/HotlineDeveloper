using UnityEngine;

namespace Modules.DamageSystem
{
    public interface IDamageInflictStrategy
    {
        void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData);
    }
}
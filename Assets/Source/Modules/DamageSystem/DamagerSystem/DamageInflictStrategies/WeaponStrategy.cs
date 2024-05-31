using UnityEngine;

namespace Modules.DamageSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class WeaponStrategy : MonoBehaviour, IDamageInflictStrategy
    {
        protected bool IsEquipped { get; private set; }
        protected DamageReceiverView OwnerDamageReceiver { get; private set; }

        public abstract void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData);

        public void Equip(Transform owner)
        {
            OwnerDamageReceiver = owner.GetComponentInParent<DamageReceiverView>();
        }

        public void Unequip()
        {
            OwnerDamageReceiver = null;
        }
    }
}
using Modules.Weapons.WeaponItemSystem;
using UnityEngine;

namespace Modules.DamageSystem
{
    [RequireComponent(typeof(WeaponItem))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class WeaponStrategy : MonoBehaviour, IDamageInflictStrategy
    {
        private WeaponItem _weaponItem;

        protected bool IsEquipped => _weaponItem.IsEquipped;
        protected DamageReceiverView OwnerDamageReceiver { get; private set; }

        private void Awake()
        {
            _weaponItem = GetComponent<WeaponItem>();
            _weaponItem.Equipped += OnEquip;
            _weaponItem.Thrown += OnThrowEnd;
        }

        public abstract void InflictDamage(DamageReceiverView damageReceiverView, DamageData damageData);

        private void OnEquip(Transform owner)
        {
            OwnerDamageReceiver = owner.GetComponentInParent<DamageReceiverView>();
        }

        private void OnThrowEnd()
        {
            OwnerDamageReceiver = null;
        }
    }
}
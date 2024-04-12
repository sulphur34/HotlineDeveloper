using Modules.Weapons;
using UnityEngine;

namespace Modules.WeaponItemSystem
{
    public class WeaponItem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _force;

        private Weapon _weapon;
        private Transform _startContainer;

        public bool Equipped { get; private set; }

        public void Init(Weapon weapon)
        {
            _weapon = weapon;
            _startContainer = transform.parent;
        }

        public void Attack()
        {
            _weapon.Attack();
        }

        public void Equip(Transform container)
        {
            SetEquipped(true, container);
        }

        public void Throw()
        {
            SetEquipped(false, null);
            _rigidbody.useGravity = true;
            _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
            transform.SetParent(_startContainer);
        }

        private void SetEquipped(bool value, Transform container)
        {
            Equipped = value;
            _rigidbody.useGravity = false;
            transform.SetParent(container);

            if (container != null)
                transform.position = container.position;
        }
    }
}
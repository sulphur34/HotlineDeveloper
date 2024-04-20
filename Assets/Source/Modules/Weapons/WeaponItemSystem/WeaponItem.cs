using Modules.Weapons;
using System;
using UnityEngine;

namespace Modules.WeaponItemSystem
{
    public class WeaponItem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _force;

        private Action _attack;
        private Transform _startContainer;

        public WeaponType Type { get; private set; }
        public bool Equipped { get; private set; }

        public void Init(Action attack, WeaponType type)
        {
            _attack = attack;
            Type = type;
            _startContainer = transform.parent;
        }

        public void Attack()
        {
            _attack?.Invoke();
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
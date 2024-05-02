using Modules.Weapons.WeaponTypeSystem;
using System;
using UnityEditor.Presets;
using UnityEngine;

namespace Modules.Weapons.WeaponItemSystem
{
    public class WeaponItem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Preset _rigidbodyPreset;
        [SerializeField] private float _force;

        private Transform _startContainer;

        private Action _attack;

        [field: SerializeField] public Transform LeftHandPlaceHolder { get; private set; }

        [field: SerializeField] public Transform RightHandPlaceHolder { get; private set; }

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
            _rigidbody = gameObject.AddComponent<Rigidbody>();
            _rigidbodyPreset.ApplyTo(_rigidbody);
            _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
            transform.SetParent(_startContainer);
        }

        private void SetEquipped(bool value, Transform container)
        {
            Equipped = value;
            transform.SetParent(container);

            if (container != null)
            {
                Destroy(_rigidbody);
                transform.position = container.position;
                transform.forward = container.forward;
            }
        }
    }
}
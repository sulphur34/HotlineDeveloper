using System;
using UnityEngine;

namespace Source.Modules.EquipperSystem
{
    public class Equipper
    {
        private Transform _container;
        private Transform _item;
        private float _throwSpeed;

        public event Action<Transform> Equipped;
        public event Action Detached;

        public Equipper(Transform container, float throwSpeed)
        {
            _container = container;
            _throwSpeed = throwSpeed;
        }

        private void Equip(Transform item)
        {
            Detach();
            _item = item;
            item.SetParent(_container, false);
        }

        private void Detach()
        {
            Transform item = _item;
            item.transform.parent = null;
            Throw(item);
        }

        private void Throw(Transform item)
        {
            Rigidbody rigidbody = _item.GetComponent<Rigidbody>();
            rigidbody.AddForce(_container.forward * _throwSpeed);
        }
    }
}
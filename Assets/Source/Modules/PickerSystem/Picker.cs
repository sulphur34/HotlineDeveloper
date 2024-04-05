using System;
using System.Linq;
using UnityEngine;

namespace Modules.PickerSystem
{
    public class Picker : IPicker
    {
        private float _pickRadius;
        private Vector3 _pickPosition;
        private Transform _transform;
        private Transform _itemPlaceholder;

        private Transform _item;

        public event Action<Transform> Picked;

        public Picker(PickerConfig config, Transform transform, Transform itemPlaceholder)
        {
            _pickRadius = config.PickRadius;
            _transform = transform;
            _itemPlaceholder = itemPlaceholder;
        }

        public void Pick()
        {
            Transform pickable = GetNearestItem();

            if (pickable == null)
                return;

            Picked?.Invoke(pickable);
        }

        private void EquipItem(Transform pickable)
        {
            pickable.SetParent(_itemPlaceholder);
        }

        private Transform GetNearestItem()
        {
            _item = Physics.OverlapSphere(_pickPosition, _pickRadius)
                .Where(collider => collider.GetComponent<IPickable>() != null)
                .OrderBy(collider => (collider.transform.position - _transform.position).magnitude)
                .FirstOrDefault()
                ?.transform;

            return _item;
        }
    }
}
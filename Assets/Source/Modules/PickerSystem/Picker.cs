using System;
using System.Linq;
using UnityEngine;

namespace Modules.PickerSystem
{
    public class Picker : MonoBehaviour, IPicker
    {
        private float _radius;
        private Transform _position;

        private Transform _item;

        public event Action<Transform> Picked;

        public Picker(PickerConfig config)
        {
            _radius = config.Radius;
            _position = config.Position;
        }

        public void Pick()
        {
            Transform pickable = GetNearestItem();

            if (pickable == null)
                return;

            Picked?.Invoke(pickable);
        }

        private Transform GetNearestItem()
        {
            _item = Physics.OverlapSphere(_position.position, _radius)
                .Where(collider => collider.GetComponent<IPickable>() != null && collider.transform != _item)
                .OrderBy(collider => (collider.transform.position - _position.position).magnitude)
                .FirstOrDefault()
                ?.transform;

            return _item;
        }
    }
}
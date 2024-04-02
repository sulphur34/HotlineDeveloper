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
        
        public event Action<IPickable> Picked;

        public Picker(PickerConfig config, Transform transform)
        {
            _pickRadius = config.PickRadius;
            _transform = transform;
        }

        public void Pick()
        {
            IPickable pickable = GetNearestItem();
            
            if (pickable == null)
                return;
            
            Picked?.Invoke(pickable);
        }

        private IPickable GetNearestItem()
        {
            IPickable item = Physics.OverlapSphere(_pickPosition, _pickRadius)
                .Where(collider => collider.GetComponent<IPickable>() != null)
                .OrderBy(collider => (collider.transform.position - _transform.position).magnitude)
                .Select(collider => collider.GetComponent<IPickable>())
                .FirstOrDefault();

            return item;
        }
    }
}
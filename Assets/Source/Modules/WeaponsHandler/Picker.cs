using System.Linq;
using Modules.WeaponItemSystem;
using UnityEngine;

namespace Modules.WeaponsHandler
{
    public class Picker
    {
        private readonly Transform _pickPoint;
        private readonly float _pickRadius;
        private readonly WeaponItem _currentWeaponItem;
        private readonly float _lookHeight;

        public Picker(WeaponItem currentWeaponItem, Transform pickPoint, float pickRadius, float lookHeight)
        {
            _pickPoint = pickPoint;
            _pickRadius = pickRadius;
            _currentWeaponItem = currentWeaponItem;
            _lookHeight = lookHeight;
        }

        public bool TryGetWeapon(out WeaponItem weaponItem)
        {
            weaponItem = Physics.OverlapSphere(_pickPoint.position, _pickRadius)
                .Where(IsAvailableWeapon)
                .Where(IsNoObstacles)
                .OrderBy(collider => (collider.transform.position - _pickPoint.position).magnitude)
                .FirstOrDefault()
                ?.GetComponent<WeaponItem>();

            return weaponItem != null;
        }

        private bool IsAvailableWeapon(Collider collider)
        {
            WeaponItem weaponItem = collider.GetComponent<WeaponItem>();
            return weaponItem != null && weaponItem != _currentWeaponItem && !weaponItem.IsEquipped;
        }

        private bool IsNoObstacles(Collider collider)
        {
            Vector3 alignedPosition = _pickPoint.position;
            alignedPosition.y += _lookHeight;

            if (!Physics.Linecast(alignedPosition, collider.transform.position, out RaycastHit hit))
                return false;

            return hit.collider.TryGetComponent(out WeaponItem weaponItem);
        }
    }
}
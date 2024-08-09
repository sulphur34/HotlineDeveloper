using System.Collections.Generic;
using System.Linq;
using Modules.WeaponItemSystem;
using UnityEngine;

namespace Modules.WeaponItemSystem
{
    public class WeaponTracker
    {
        private List<WeaponItem> _weapons;
    
        public void Initialize(List<WeaponItem> weapons)
        {
            _weapons = weapons.Where(weaponItem => weaponItem.IsTrackable).ToList();
        }

        public bool TryGetNearest(Vector3 position, out WeaponItem weaponItem)
        {
            weaponItem =_weapons
                .Where(weapon => weapon.IsEquipped == false)
                .OrderBy(weapon => Vector3.Distance(position, weapon.transform.position))
                .FirstOrDefault();

            return weaponItem != null;
        }
    }
}

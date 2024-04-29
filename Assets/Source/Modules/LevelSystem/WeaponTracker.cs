using System.Collections.Generic;
using System.Linq;
using Source.Modules.Weapons.WeaponItemSystem;
using UnityEngine;

public class WeaponTracker
{
    private List<WeaponItem> _weapons;

    public WeaponTracker()
    {
        _weapons = new List<WeaponItem>();
    }

    public void Add(WeaponItem weaponItem)
    {
        _weapons.Add(weaponItem);
    }

    public bool TryGetNearest(Vector3 position, out WeaponItem weaponItem)
    {
        weaponItem =_weapons
            .Where(weapon => weapon.Equipped == false)
            .OrderBy(weapon => Vector3.Distance(position, weapon.transform.position))
            .FirstOrDefault();

        return weaponItem != null;
    }
}

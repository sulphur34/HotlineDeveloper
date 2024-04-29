using System.Collections.Generic;
using System.Linq;
using Modules.Weapons.WeaponItemSystem;
using UnityEngine;
using VContainer;

public class WeaponTracker : MonoBehaviour
{
    private List<WeaponItem> _weapons;

    [Inject]
    public void Construct()
    {
        _weapons = GetComponentsInChildren<WeaponItem>().ToList();
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

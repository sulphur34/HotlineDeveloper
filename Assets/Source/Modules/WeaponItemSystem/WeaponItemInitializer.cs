using System.Collections.Generic;
using System.Linq;
using Modules.Weapons.Range;
using UnityEngine;
using VContainer;

namespace Modules.Weapons.WeaponItemSystem
{
    public class WeaponItemInitializer : MonoBehaviour
    {
        private List<WeaponItem> _weapons;
        private RangeWeaponConfigFactory _rangeWeaponConfigFactory;

        [Inject]
        private void Construct(WeaponTracker weaponTracker, RangeWeaponConfigFactory rangeWeaponConfigFactory)
        {
            _rangeWeaponConfigFactory = rangeWeaponConfigFactory;
            _weapons = GetComponentsInChildren<WeaponItem>().ToList();
            InitializeWeapons();
            weaponTracker.Initialize(_weapons);
        }

        public void InitializeWeapon(WeaponItem weaponItem)
        {
            if(weaponItem == null)
                return;
            
            WeaponSetup weaponSetup = weaponItem.GetComponent<WeaponSetup>();

            if (weaponSetup.GetType() == typeof(RangeWeaponSetup))
                ((RangeWeaponSetup)weaponSetup).SetShotStrategy(_rangeWeaponConfigFactory);
                
            weaponSetup.Initialize();
            weaponItem.Initialize(weaponSetup);
        }
        
        private void InitializeWeapons()
        {
            foreach (WeaponItem weapon in _weapons)
            {
                InitializeWeapon(weapon);
            }
        }
    }
}
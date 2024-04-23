using System;

namespace Modules.Weapons.WeaponItemSystem
{ 
    public interface IWeaponItemInput
    {
        public event Action Received;
    }
}
using Modules.Weapons.Ammunition;
using Modules.WeaponTypes;
using UnityEngine;

namespace Modules.Weapons.WeaponItemSystem
{
    public interface IWeaponInfo
    {
        Transform SelfTransform { get; }
        Transform LeftHandPlaceHolder { get;}
        Transform RightHandPlaceHolder { get;}
        IAmmunitionView _weaponAmmunitionView { get; }
        WeaponType WeaponType { get; }
        bool IsEquipped { get; }
    }
}
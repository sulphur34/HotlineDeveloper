using Modules.Weapons.WeaponTypeSystem;
using UnityEngine;

namespace Modules.Weapons.WeaponItemSystem
{
    public interface IWeaponInfo
    {
        Transform LeftHandPlaceHolder { get;}
        Transform RightHandPlaceHolder { get;}
        WeaponType WeaponType { get; }
        bool IsEquipped { get; }
    }
}
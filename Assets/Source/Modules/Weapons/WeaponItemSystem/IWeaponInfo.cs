using Modules.Weapons.WeaponTypeSystem;
using UnityEngine;

namespace Modules.Weapons.WeaponItemSystem
{
    public interface IWeaponInfo
    {
        Transform SelfTransform { get; }
        Transform LeftHandPlaceHolder { get;}
        Transform RightHandPlaceHolder { get;}
        WeaponType WeaponType { get; }
        bool IsEquipped { get; }
    }
}
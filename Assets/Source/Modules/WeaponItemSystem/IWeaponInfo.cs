using Modules.Weapons.Ammunition;
using Modules.WeaponTypes;
using UnityEngine;

namespace Modules.WeaponItemSystem
{
    public interface IWeaponInfo
    {
        Transform SelfTransform { get; }

        Transform LeftHandPlaceHolder { get; }

        Transform RightHandPlaceHolder { get; }

        IAmmunitionView WeaponAmmunitionView { get; }

        WeaponType WeaponType { get; }

        bool IsEquipped { get; }
    }
}
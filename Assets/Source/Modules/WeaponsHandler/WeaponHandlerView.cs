using System;
using Modules.Weapons.WeaponItemSystem;
using Modules.Weapons.WeaponTypeSystem;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Modules.PlayerWeaponsHandler
{
    public class WeaponHandlerView : MonoBehaviour
    {
        [SerializeField] private RigBuilder _rigBuilder;
        [SerializeField] private TwoBoneIKConstraint _rightHandConstraint;
        [SerializeField] private TwoBoneIKConstraint _leftHandConstraint;
        
        public event Action RangeShotFired;
        public event Action Unequipped;

        public IWeaponHandlerInfo WeaponHandlerInfo { get; private set; }

        public void Initialize(IWeaponHandlerInfo weaponHandlerInfo)
        {
            WeaponHandlerInfo = weaponHandlerInfo;
        }
        
        public void OnAttack(WeaponType weaponType)
        {
            if (weaponType == WeaponType.Range)
                RangeShotFired?.Invoke();
        }

        public void OnPick(IWeaponInfo weaponItem)
        {
            _rightHandConstraint.data.target = weaponItem.RightHandPlaceHolder;
            
            if(weaponItem.RightHandPlaceHolder != null)
                _leftHandConstraint.data.target = weaponItem.RightHandPlaceHolder;
            
            _rigBuilder.Build();
        }

        public void UnequipWeapon()
        {
            Unequipped.Invoke();
        }
    }
}
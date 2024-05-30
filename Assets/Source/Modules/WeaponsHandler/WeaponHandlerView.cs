using System;
using Modules.Weapons.WeaponItemSystem;
using Modules.Weapons.WeaponTypeSystem;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Modules.PlayerWeaponsHandler
{
    public class WeaponHandlerView : MonoBehaviour
    {
        public const string TwoHandsAttackName = "TwoHandsAttack";
        public const string OneHandAttackName = "OneHandAttack";
        public const string BareHandsAttack = "BareHandsAttack";

        [SerializeField] private RigBuilder _rigBuilder;
        [SerializeField] private Rig _rangeRig;
        [SerializeField] private TwoBoneIKConstraint _rightHandRange;
        [SerializeField] private TwoBoneIKConstraint _leftHandRange;
        [SerializeField] private Rig _meleeRig;
        [SerializeField] private MultiParentConstraint _rightHandMelee;
        [SerializeField] private TwoBoneIKConstraint _leftHandMelee;

        private Animator _animator;
        private int _twoHandsAttackId;
        private int _oneHandAttackId;
        private int _bareHandsAttackId;
        private bool _isTwoHanded;

        public event Action RangeShotFired;
        public event Action Equipped;
        public event Action Unequipped;

        public IWeaponHandlerInfo WeaponInfo { get; private set; }

        public void Initialize(IWeaponHandlerInfo weaponHandlerInfo)
        {
            WeaponInfo = weaponHandlerInfo;
            _animator = GetComponent<Animator>();
            _twoHandsAttackId = Animator.StringToHash(TwoHandsAttackName);
            _bareHandsAttackId = Animator.StringToHash(BareHandsAttack);
            _oneHandAttackId = Animator.StringToHash(OneHandAttackName);
        }

        public void OnAttack(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.Melee:
                    SetMeleeAnimation();
                    break;
                case WeaponType.BareHands:
                    _animator.SetTrigger(_bareHandsAttackId);
                    break;
            }

            if (weaponType == WeaponType.Range)
                RangeShotFired?.Invoke();
        }

        public void OnPick(IWeaponInfo weaponItem)
        {
            Equipped?.Invoke();

            switch (WeaponInfo.CurrentWeaponType)
            {
                case WeaponType.Melee:
                    EquipMelee(weaponItem);
                    break;

                case WeaponType.Range:
                    EquipRange(weaponItem);
                    break;
                
                case WeaponType.BareHands:
                    EquipMelee(weaponItem);
                    break;
            }
        }

        public void UnequipWeapon()
        {
            ClearHands();
            Unequipped.Invoke();
        }

        public void ClearHands()
        {
            _rangeRig.weight = 0f;
            _meleeRig.weight = 0f;
        }

        private void EquipRange(IWeaponInfo weaponItem)
        {
            _rangeRig.weight = 1f;
            _rightHandRange.data.target = weaponItem.RightHandPlaceHolder;

            if (weaponItem.LeftHandPlaceHolder != null)
                _leftHandRange.data.target = weaponItem.LeftHandPlaceHolder;

            _rigBuilder.Build();
        }

        private void EquipMelee(IWeaponInfo weaponItem)
        {
            _meleeRig.weight = 1f;
            _rightHandMelee.data.constrainedObject = weaponItem.SelfTransform;

            if (weaponItem.LeftHandPlaceHolder != null)
            {
                _leftHandMelee.data.target = weaponItem.LeftHandPlaceHolder;
                _isTwoHanded = true;
            }
            else
            {
                _isTwoHanded = false;
            }

            _rigBuilder.Build();
        }

        private void SetMeleeAnimation()
        {
            if (_isTwoHanded)
                _animator.SetTrigger(_twoHandsAttackId);
            else
                _animator.SetTrigger(_oneHandAttackId);
        }
    }
}
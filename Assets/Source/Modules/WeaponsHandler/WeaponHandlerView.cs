using System;
using Modules.DamageSystem;
using Modules.Weapons.WeaponItemSystem;
using Modules.Weapons.WeaponTypeSystem;
using Source.Game.Scripts.Animations;
using UnityEngine;

namespace Modules.PlayerWeaponsHandler
{
    public class WeaponHandlerView : MonoBehaviour
    {
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private DamageReceiverView _damageReceiverView;
        
        public event Action RangeShotFired;
        public event Action Equipped;
        public event Action Unequipped;

        public IWeaponHandlerInfo WeaponInfo { get; private set; }

        public void Initialize(IWeaponHandlerInfo weaponHandlerInfo)
        {
            WeaponInfo = weaponHandlerInfo;
            _animationController = GetComponent<AnimationController>();
            _damageReceiverView = GetComponent<DamageReceiverView>();
            _damageReceiverView.FallenDown += UnequipWeapon;
        }

        public void OnAttack(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.Melee:
                    _animationController.AttackMelee();
                    break;
                case WeaponType.BareHands:
                    _animationController.AttackBareHands();
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
                    _animationController.PickMelee(weaponItem.SelfTransform, weaponItem.LeftHandPlaceHolder);
                    break;

                case WeaponType.Range:
                    _animationController.PickRange(weaponItem.RightHandPlaceHolder, weaponItem.LeftHandPlaceHolder);
                    break;

                case WeaponType.BareHands:
                    _animationController.PickMelee(weaponItem.SelfTransform, weaponItem.LeftHandPlaceHolder);
                    break;
            }
        }

        public void UnequipWeapon()
        {
            ClearHands();
            Unequipped?.Invoke();
        }

        public void ClearHands()
        {
            _animationController.Unequip();
        }
    }
}
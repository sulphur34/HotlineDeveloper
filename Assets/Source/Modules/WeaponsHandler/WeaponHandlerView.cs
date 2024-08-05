using System;
using Modules.DamageReceiverSystem;
using Modules.Weapons.Ammunition;
using Modules.Weapons.WeaponItemSystem;
using Modules.Weapons.WeaponTypeSystem;
using Modules.AnimationSystem;
using UnityEngine;

namespace Modules.PlayerWeaponsHandler
{
    public class WeaponHandlerView : MonoBehaviour
    {
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private DamageReceiverView _damageReceiverView;
        [SerializeField] private AmmunitionUI _ammunitionUI;

        private IAmmunitionView _currentAmmunitionView;

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
            _ammunitionUI?.Deactivate();
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
            SetAnimation(weaponItem);
            
            if(weaponItem.WeaponType == WeaponType.Range)
                SetAmmoUI(true, weaponItem._weaponAmmunitionView);
            else
                _ammunitionUI?.Deactivate();
        }

        public void UnequipWeapon()
        {
            if(!WeaponInfo.CurrentWeaponItemIsEmpty &&
               WeaponInfo.CurrentWeaponType == WeaponType.Range)
                SetAmmoUI(false, _currentAmmunitionView);
            
            ClearHands();
            Unequipped?.Invoke();
        }

        public void ClearHands()
        {
            _animationController.Unequip();
        }

        private void SetAnimation(IWeaponInfo weaponItem)
        {
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

        private void SetAmmoUI(bool isActive, IAmmunitionView ammunitionView)
        {
            if (_ammunitionUI == null)
                return;

            if (isActive)
            {
                _currentAmmunitionView = ammunitionView;
                _ammunitionUI.Activate(_currentAmmunitionView.CurrentAmmoCount);
                _ammunitionUI.Initialize(_currentAmmunitionView.AmmoIcon);
                _currentAmmunitionView.Changed += _ammunitionUI.UpdateAmmo;
            }
            else
            {
                _currentAmmunitionView.Changed -= _ammunitionUI.UpdateAmmo;
                _ammunitionUI.Deactivate();
            }
        }
    }
}
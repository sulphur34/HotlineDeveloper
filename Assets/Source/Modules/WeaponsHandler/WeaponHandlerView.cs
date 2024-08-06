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

        private WeaponHandlerAnimator _weaponHandlerAnimator;
        private AmmoUIHandler _ammoUIHandler;
        private IAmmunitionView _currentAmmunitionView;

        public event Action RangeShotFired;
        public event Action Equipped;
        public event Action Unequipped;

        public IWeaponHandlerInfo WeaponInfo { get; private set; }

        public void Initialize(IWeaponHandlerInfo weaponHandlerInfo)
        {
            WeaponInfo = weaponHandlerInfo;
            _weaponHandlerAnimator = new WeaponHandlerAnimator(_animationController);
            _ammoUIHandler = new AmmoUIHandler(_ammunitionUI, _currentAmmunitionView);
            _animationController = GetComponent<AnimationController>();
            _damageReceiverView = GetComponent<DamageReceiverView>();
            _damageReceiverView.FallenDown += UnequipWeapon;
            _ammunitionUI?.Deactivate();
        }

        public void OnAttack(WeaponType weaponType)
        {
            _weaponHandlerAnimator.AnimateAttack(weaponType);

            if (weaponType == WeaponType.Range)
                RangeShotFired?.Invoke();
        }

        public void OnPick(IWeaponInfo weaponItem)
        {
            Equipped?.Invoke();
            _weaponHandlerAnimator.AnimatePick(WeaponInfo, weaponItem);

            if (weaponItem.WeaponType == WeaponType.Range)
                _ammoUIHandler.SetAmmoUI(true, weaponItem._weaponAmmunitionView);
            else
                _ammunitionUI?.Deactivate();
        }

        private void UnequipWeapon()
        {
            if (!WeaponInfo.CurrentWeaponItemIsEmpty &&
                WeaponInfo.CurrentWeaponType == WeaponType.Range)
                _ammoUIHandler.SetAmmoUI(false, _currentAmmunitionView);

            ClearHands();
            Unequipped?.Invoke();
        }

        public void ClearHands()
        {
            _weaponHandlerAnimator.AnimateClearHands();
        }
    }
}
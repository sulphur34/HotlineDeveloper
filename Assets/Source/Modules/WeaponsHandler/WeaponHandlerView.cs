using System;
using Modules.AnimationSystem;
using Modules.DamagerSystem;
using Modules.WeaponItemSystem;
using Modules.Weapons.Ammunition;
using Modules.WeaponTypes;
using UnityEngine;

namespace Modules.WeaponsHandler
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

        public IWeaponHandlerInfo WeaponInfo { get; private set; }

        public void Initialize()
        {
            _weaponHandlerAnimator = new WeaponHandlerAnimator(_animationController);
            _ammoUIHandler = new AmmoUIHandler(_ammunitionUI, _currentAmmunitionView);
            _animationController = GetComponent<AnimationController>();

            _ammunitionUI?.Deactivate();
        }

        public void OnAttack(WeaponType weaponType)
        {
            _weaponHandlerAnimator.AnimateAttack(weaponType);

            if (weaponType == WeaponType.Range)
                RangeShotFired?.Invoke();
        }

        public void OnPick(IWeaponInfo weaponItem, IWeaponHandlerInfo handlerInfo)
        {
            WeaponInfo = handlerInfo;
            Equipped?.Invoke();
            _weaponHandlerAnimator.AnimatePick(WeaponInfo, weaponItem);

            if (weaponItem.WeaponType == WeaponType.Range)
                _ammoUIHandler.SetAmmoUI(true, weaponItem.WeaponAmmunitionView);
            else
                _ammunitionUI?.Deactivate();
        }

        public void UnequipWeapon(IWeaponHandlerInfo handlerInfo)
        {
            WeaponInfo = handlerInfo;

            if (!WeaponInfo.IsCurrentWeaponItemEmpty && WeaponInfo.CurrentWeaponType == WeaponType.Range)
                _ammoUIHandler.SetAmmoUI(false, _currentAmmunitionView);

            ClearHands();
        }

        public void ClearHands()
        {
            _weaponHandlerAnimator.AnimateClearHands();
        }
    }
}
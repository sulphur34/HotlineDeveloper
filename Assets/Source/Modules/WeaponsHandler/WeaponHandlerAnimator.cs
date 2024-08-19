using Modules.AnimationSystem;
using Modules.WeaponItemSystem;
using Modules.WeaponsTypes;

namespace Modules.WeaponsHandler
{
    internal class WeaponHandlerAnimator
    {
        private AnimationController _animationController;

        public WeaponHandlerAnimator(AnimationController animationController)
        {
            _animationController = animationController;
        }

        public void AnimateAttack(WeaponType weaponType)
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
        }

        public void AnimateClearHands()
        {
            _animationController.Unequip();
        }

        public void AnimatePick(IWeaponHandlerInfo weaponInfo, IWeaponInfo weaponItem)
        {
            switch (weaponInfo.CurrentWeaponType)
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
    }
}
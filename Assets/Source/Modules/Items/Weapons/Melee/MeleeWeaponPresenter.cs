using Modules.Items.Weapons.InputSystem;

namespace Modules.Items.Weapons.Melee
{
    internal class MeleeWeaponPresenter : WeaponPresenter
    {
        private readonly MeleeWeaponView _meleeWeaponView;

        internal MeleeWeaponPresenter(Weapon weapon, IShotInput input, MeleeWeaponView meleeWeaponView) : base(weapon, input) 
        {
            _meleeWeaponView = meleeWeaponView;
        }

        protected override void RunAfterAttack()
        {
            _meleeWeaponView.Animate();
        }
    }
}
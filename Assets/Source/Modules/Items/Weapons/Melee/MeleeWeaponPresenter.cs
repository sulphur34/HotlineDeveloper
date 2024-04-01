using Modules.Items.Weapons.InputSystem;

namespace Modules.Items.Weapons.Melee
{
    internal class MeleeWeaponPresenter : WeaponPresenter
    {
        private readonly MeleeWeaponView _meleeWeaponView;

        internal MeleeWeaponPresenter(IAttacker attacker, IShotInput input, MeleeWeaponView meleeWeaponView) : base(attacker, input) 
        {
            _meleeWeaponView = meleeWeaponView;
        }

        protected override void RunAfterAttack()
        {
            _meleeWeaponView.Animate();
        }
    }
}
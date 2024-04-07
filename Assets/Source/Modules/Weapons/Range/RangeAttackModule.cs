using Modules.Items.Weapons.Ammunition;

namespace Modules.Items.Weapons.Range
{
    internal class RangeAttackModule : IAttackModule
    {
        private readonly ShotStrategy _shotStrategy;
        private readonly WeaponAmmunition _ammunition;

        public RangeAttackModule(ShotStrategy shotStrategy, WeaponAmmunition ammunition)
        {
            _shotStrategy = shotStrategy;
            _ammunition = ammunition;
        }

        public void Attack()
        {
            if (_ammunition.Count > 0)
            {
                _shotStrategy.Shot();
                _ammunition.Remove();
            }
        }
    }
}
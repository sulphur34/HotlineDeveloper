using Modules.Ammunition;
using Modules.Weapons.ShotStrategies;

namespace Modules.Weapons.Range
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

        public bool TryAttack()
        {
            if (_ammunition.Count > 0)
            {
                _shotStrategy.Shot();
                _ammunition.Remove();
                return true;
            }

            return false;
        }
    }
}
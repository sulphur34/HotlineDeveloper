using Modules.Items.Weapons.Ammunition;
using UnityEngine;

namespace Modules.Items.Weapons.Range
{
    internal class RangeWeapon : Weapon
    {
        private readonly ShotStrategy _shotStrategy;
        private readonly WeaponAmmunition _ammunition;

        public RangeWeapon(
            MonoBehaviour coroutineStarter, 
            float rechargeTime, 
            ShotStrategy shotStrategy, 
            WeaponAmmunition ammunition) : base(coroutineStarter, rechargeTime)
        {
            _shotStrategy = shotStrategy;
            _ammunition = ammunition;
        }

        protected override bool CanAttack => _ammunition.Count > 0;

        protected override void RealizeAttack()
        {
            _shotStrategy.Shot();
            _ammunition.Remove();
        }
    }
}
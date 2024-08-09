using System;
using Cysharp.Threading.Tasks;
using Modules.Weapons.WeaponTypeSystem;
using Modules.WeaponTypes;
using UnityEngine;

namespace Modules.Weapons
{
    public abstract class WeaponSetup : MonoBehaviour
    {
        private readonly WeaponTypeGetter _weaponTypeGetter = new WeaponTypeGetter();

        public Func<bool> AttackHandler { get; private set; }
        public WeaponType WeaponType { get; private set; }
        public Action AttackInterruptHandler { get; private set; }

        public virtual void Initialize()
        {
        }

        protected void SetWeapon(float rechargeTime, IAttackModule attackModule,
            IInterruptModule interruptModule = null)
        {
            WeaponRechargeTime weaponRechargeTime = new WeaponRechargeTime(rechargeTime);
            Weapon weapon = new Weapon(weaponRechargeTime, attackModule, this.GetCancellationTokenOnDestroy(),
                interruptModule);
            AttackHandler = weapon.TryAttack;
            WeaponType = _weaponTypeGetter.Get(attackModule);
            AttackInterruptHandler = weapon.Interrupt;
        }
    }
}
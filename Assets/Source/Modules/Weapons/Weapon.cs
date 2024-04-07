using System;
using System.Threading;

namespace Modules.Items.Weapons
{
    internal class Weapon
    {
        private readonly WeaponRechargeTime _rechargeTime;
        private readonly IAttackModule _attackModule;
        private readonly CancellationToken _cancellationToken;

        internal Weapon(WeaponRechargeTime rechargeTime, IAttackModule attackModule, CancellationToken cancellationToken)
        {
            _rechargeTime = rechargeTime;
            _attackModule = attackModule;
            _cancellationToken = cancellationToken;
        }

        internal event Action Attacked;

        internal void Attack()
        {
            if (_rechargeTime.Recharged)
            {
                _attackModule.Attack();
                _rechargeTime.Discharge();
                _rechargeTime.WaitRecharged(_cancellationToken);
                Attacked?.Invoke();
            }
        }
    }
}
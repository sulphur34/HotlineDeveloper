using System;
using System.Threading;

namespace Modules.Weapons
{
    public class Weapon
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

        internal bool TryAttack()
        {
            bool isRecharged = _rechargeTime.Recharged;
            bool canAttack = false;
            
            if (isRecharged)
            {
                canAttack = _attackModule.TryAttack();
                _rechargeTime.Discharge();
                _rechargeTime.WaitRecharged(_cancellationToken);
                Attacked?.Invoke();
            }

            return isRecharged && canAttack;
        }
    }
}
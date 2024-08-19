using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.Weapons
{
    internal class WeaponRechargeTime
    {
        private readonly float _delay;

        internal WeaponRechargeTime(float delay)
        {
            _delay = delay;
        }

        internal bool Recharged { get; private set; } = true;

        internal async UniTask WaitRecharged(CancellationToken cancellationToken)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);
            Recharged = true;
        }

        internal void Discharge()
        {
            Recharged = false;
        }
    }
}
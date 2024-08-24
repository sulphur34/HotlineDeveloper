using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.Weapons.Melee
{
    internal class MeleeAttackModule : IAttackModule, IInterruptModule
    {
        private readonly Collider _collider;
        private readonly float _attackTime;

        private CancellationTokenSource _cancellationTokenSource;

        public MeleeAttackModule(Collider collider, float attackTime)
        {
            _collider = collider;
            _attackTime = attackTime;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Dispose();
        }

        public bool TryAttack()
        {
            _collider.enabled = true;
            DisableAttack();
            return true;
        }

        public void Interrupt()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private async UniTask DisableAttack()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_attackTime), cancellationToken: _cancellationTokenSource.Token);
            _collider.enabled = false;
        }
    }
}
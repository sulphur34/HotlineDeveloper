using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.Weapons.Melee
{
    internal class MeleeAttackModule : IAttackModule
    {
        private readonly Collider _collider;
        private readonly float _attackTime;
        private readonly CancellationToken _cancellationToken;

        public MeleeAttackModule(Collider collider, float attackTime, CancellationToken cancellationToken)
        {
            _collider = collider;
            _attackTime = attackTime;
            _cancellationToken = cancellationToken;
        }

        public bool TryAttack()
        {
            _collider.enabled = true;
            DisableAttack();
            return true;
        }

        private async UniTask DisableAttack()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_attackTime), cancellationToken: _cancellationToken);
            _collider.enabled = false;
        }
    }
}
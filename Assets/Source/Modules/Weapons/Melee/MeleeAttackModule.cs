using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.Weapons.Melee
{
    internal class MeleeAttackModule : IAttackModule
    {
        private readonly Collider _collider;
        private readonly float _attakeTime;
        private readonly CancellationToken _cancellationToken;

        public MeleeAttackModule(Collider collider, float attakeTime, CancellationToken cancellationToken)
        {
            _collider = collider;
            _attakeTime = attakeTime;
            _cancellationToken = cancellationToken;
        }

        public void Attack()
        {
            _collider.enabled = true;
            DisableAttack();
        }

        private async UniTask DisableAttack()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_attakeTime), cancellationToken: _cancellationToken);
            _collider.enabled = false;
        }
    }
}
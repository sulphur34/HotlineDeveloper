using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.DamagerSystem
{
    internal class Consciousness
    {
        private readonly float _recoverTime;
        private readonly CancellationToken _cancellationToken;

        internal Consciousness(float recoverTime, CancellationToken cancellationToken)
        {
            _recoverTime = recoverTime;
            _cancellationToken = cancellationToken;
        }

        internal bool IsKnocked { get; private set; }

        internal void Knockout(Action onKnockedCallback, Action onRecoveredCallback)
        {
            IsKnocked = true;
            onKnockedCallback?.Invoke();
            Recovering(_cancellationToken, onRecoveredCallback);
        }

        private async UniTask Recovering(CancellationToken cancellationToken, Action onRecoveredCallback)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_recoverTime), cancellationToken: cancellationToken);
            IsKnocked = false;
            onRecoveredCallback?.Invoke();
        }
    }
}
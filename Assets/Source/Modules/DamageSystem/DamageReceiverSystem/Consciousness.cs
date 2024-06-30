using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.DamageSystem
{
    public class Consciousness
    {
        private float _recoverTime;
        private CancellationToken _cancellationToken;

        public event Action Knocked;
        public event Action Recovered;
    
        public Consciousness(float recoverTime, CancellationToken cancellationToken)
        {
            _recoverTime = recoverTime;
            _cancellationToken = cancellationToken;
        }
        
        public bool IsKnocked { get; private set; }

        public void Knockout(Action onKnockedCallback, Action onRecoveredCallback)
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

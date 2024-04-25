using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.DamageSystem
{
    public class Consciousness : IKnockable
    {
        private float _recoverTime;
        private CancellationToken _cancellationToken;
        public bool IsConscious { get; private set; }

        public event Action Knocked;
        public event Action Recovered;
    
        public Consciousness(float recoverTime, CancellationToken cancellationToken)
        {
            _recoverTime = recoverTime;
            _cancellationToken = cancellationToken;
        }

        public void Knockout()
        {
            IsConscious = false;
            Knocked?.Invoke();
            Recovering(_cancellationToken);
        }
        
        public async UniTask Recovering(CancellationToken cancellationToken)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_recoverTime), cancellationToken: cancellationToken);
            IsConscious = true;
            Recovered?.Invoke();
        }
    }
}

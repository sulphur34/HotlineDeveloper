using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.DamageSystem
{
    public class Consciouness : IKnockable
    {
        private float _recoverTime;
        private CancellationToken _cancellationToken;
        public bool IsConscious { get; private set; }

        public event Action Knoked;
        public event Action Recovered;
    
        public Consciouness(float recoverTime, CancellationToken cancellationToken)
        {
            _recoverTime = recoverTime;
            _cancellationToken = cancellationToken;
        }

        public void Knockout()
        {
            IsConscious = false;
            Knoked?.Invoke();
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

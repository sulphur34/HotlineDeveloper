using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Modules.DamageSystem
{
    public class ConsciousnessSetup : MonoBehaviour
    {
        private ConsciounessPresenter _consciousnessPresenter;

        [Inject]
        public void Construct(ConsciousnessConfig config, ConsciounessPresenter consciousnessPresenter, ConsciousnessView consciousnessView)
        {
            Consciousness consciousness = new Consciousness(config.RecoverTime, this.GetCancellationTokenOnDestroy());
            _consciousnessPresenter = new ConsciounessPresenter(consciousness, consciousnessView);
        }

        private void OnDestroy()
        {
            _consciousnessPresenter.Dispose();
        }
    }
}
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Modules.DamageSystem
{
    public class ConsciounessSetup : MonoBehaviour
    {
        private ConsciounessPresenter _consciounessPresenter;

        [Inject]
        public void Construct(ConsciounessConfig config, ConsciounessPresenter consciounessPresenter, ConsciounessView consciounessView)
        {
            Consciouness consciouness = new Consciouness(config.RecoverTime, this.GetCancellationTokenOnDestroy());
            _consciounessPresenter = new ConsciounessPresenter(consciouness, consciounessView);
        }

        private void OnDestroy()
        {
            _consciounessPresenter.Dispose();
        }
    }
}
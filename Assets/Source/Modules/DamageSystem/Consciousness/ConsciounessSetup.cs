using UnityEngine;
using VContainer;

namespace Modules.DamageSystem
{
    public class ConsciounessSetup : MonoBehaviour
    {
        private ConditionPresenter _conditionPresenter;

        [Inject]
        public void Construct(ConsciounessConfig config, ConditionPresenter conditionPresenter, ConsciounessView consciounessView)
        {
            Consciouness consciouness = new Consciouness(config.RecoverTime);
            _conditionPresenter = new ConditionPresenter(consciouness, consciounessView);
        }

        private void OnDestroy()
        {
            _conditionPresenter.Dispose();
        }
    }
}
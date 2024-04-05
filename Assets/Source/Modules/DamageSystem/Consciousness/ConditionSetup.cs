using UnityEngine;
using VContainer;

namespace Modules.DamageSystem
{
    public class ConditionSetup : MonoBehaviour
    {
        private ConditionPresenter _conditionPresenter;

        [Inject]
        public void Construct(ConditionConfig config, ConditionPresenter conditionPresenter, ConditionView conditionView)
        {
            Condition condition = new Condition(config.RecoverTime);
            _conditionPresenter = new ConditionPresenter(condition, conditionView);
        }

        private void OnDestroy()
        {
            _conditionPresenter.Dispose();
        }
    }
}
using UnityEngine;
using VContainer;

namespace Modules.DamageSystem
{
    public class HealthSetup : MonoBehaviour
    {
        private HealthPresenter _healthPresenter;

        [Inject]
        public void Construct(HealthConfig config, HealthView view)
        {
            Health _health = new Health(config.MaxValue);
            _healthPresenter = new HealthPresenter(_health, view);
        }

        private void OnDestroy()
        {
            _healthPresenter.Dispose();
        }
    }
}
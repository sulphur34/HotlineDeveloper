using Cysharp.Threading.Tasks;
using Modules.DamageSystem;
using UnityEngine;
using VContainer;

namespace Modules.DamageSystem
{
    [RequireComponent(typeof(DamageReceiverView))]
    public class DamageReceiverSetup : MonoBehaviour
    {
        private DamageReceiverPresenter _damageReceiverPresenter;
        private DamageReceiverView _damageReceiverView;
        
        [Inject]
        public void Construct(DamageableConfig damageableConfig)
        {
            DamageReceiver damageReceiver = new DamageReceiver(damageableConfig, this.GetCancellationTokenOnDestroy());
            _damageReceiverView = GetComponent<DamageReceiverView>();
            _damageReceiverPresenter = new DamageReceiverPresenter(damageReceiver, _damageReceiverView);
        }

        private void OnDestroy()
        {
            _damageReceiverPresenter.Dispose();
        }
    }
}
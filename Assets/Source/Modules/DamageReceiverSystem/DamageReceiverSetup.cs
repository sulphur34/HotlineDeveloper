using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.DamagerSystem
{
    [RequireComponent(typeof(DamageReceiverView))]
    public class DamageReceiverSetup : MonoBehaviour
    {
        private DamageReceiverPresenter _damageReceiverPresenter;
        
        public void Initialize(DamageableConfig damageableConfig)
        {
            DamageReceiver damageReceiver = new(damageableConfig, this.GetCancellationTokenOnDestroy());
            DamageReceiverView damageReceiverView = GetComponent<DamageReceiverView>();
            _damageReceiverPresenter = new DamageReceiverPresenter(damageReceiver, damageReceiverView);
        }

        private void OnDestroy()
        {
            _damageReceiverPresenter?.Dispose();
        }
    }
}
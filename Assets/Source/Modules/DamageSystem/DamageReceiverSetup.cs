using System;
using Cysharp.Threading.Tasks;
using Modules.Characters;
using UnityEngine;

namespace Source.Modules.DamageSystem
{
    [RequireComponent(typeof(DamageReceiverView))]
    public class DamageReceiverSetup : MonoBehaviour
    {
        private DamageReceiverPresenter _damageReceiverPresenter;
        
        public void Construct(DamageableConfig damageableConfig)
        {
            DamageReceiver damageReceiver = new DamageReceiver(damageableConfig, this.GetCancellationTokenOnDestroy());
        }

        private void OnDestroy()
        {
            _damageReceiverPresenter.Dispose();
        }
    }
}
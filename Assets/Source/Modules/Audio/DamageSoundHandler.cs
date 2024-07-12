using Modules.DamageSystem;
using UnityEngine;

namespace Modules.Audio
{
    [RequireComponent(typeof(DamageReceiverView))]
    public class DamageSoundHandler : SoundHandler
    {
        [SerializeField] private AudioSourceNames _audioName;
        
        private DamageReceiverView _damageReceiverView;

        protected override void Awake()
        {
            base.Awake();
            _damageReceiverView = GetComponent<DamageReceiverView>();
            _damageReceiverView.Received += OnReceive;
        }

        private void OnReceive(DamageData damageData)
        {
            Play(_audioName);
        }
    }
}
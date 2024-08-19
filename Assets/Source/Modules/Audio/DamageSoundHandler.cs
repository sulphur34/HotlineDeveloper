using System;
using Modules.DamageReceiverSystem;
using Plugins.Audio.Utils;
using UnityEngine;

namespace Modules.Audio
{
    [RequireComponent(typeof(DamageReceiverView))]
    internal class DamageSoundHandler : SoundHandler
    {
        [SerializeField] private AudioDataProperty _audioName;

        private DamageReceiverView _damageReceiverView;

        protected override void Awake()
        {
            base.Awake();
            _damageReceiverView = GetComponent<DamageReceiverView>();

            if (_damageReceiverView == null)
                throw new NullReferenceException("Character object does not contain DamageReceiverView component");

            _damageReceiverView.Received += OnReceive;
        }

        private void OnDestroy()
        {
            _damageReceiverView.Received -= OnReceive;
        }

        private void OnReceive(DamageData damageData)
        {
            Play(_audioName);
        }
    }
}
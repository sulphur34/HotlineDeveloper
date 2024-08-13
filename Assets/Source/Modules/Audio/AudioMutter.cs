using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Modules.Audio
{
    public class AudioMutter : AudioSetter
    {
        private const int MinMixerVolume = -80;
        private const float Multiplier = 20f;
        private const float ZeroSound = 0f;

        [SerializeField] private Button _button;
        [SerializeField] private AudioMixerGroup _audioMixerGroup;
        [SerializeField] private string _mixerName;

        private float _initialVolume;
        private bool _isMuted;

        public override float Volume => _initialVolume;

        public override bool IsMuted => _isMuted;

        public override event Action Changed;

        public override void Init(float value, bool isMuted)
        {
            _initialVolume = value;
            _isMuted = isMuted;
            _button.onClick.AddListener(OnButtonClick);
            SetState(_isMuted);
        }

        private void OnButtonClick()
        {
            _isMuted = !IsMuted;
            SetState(IsMuted);
            Changed.Invoke();
        }

        private void SetState(bool isMuted)
        {
            if (isMuted)
            {
                SetMuted();
                return;
            }

            SetUnmuted();
        }

        private void SetUnmuted()
        {
            var volume = Mathf.Log10(_initialVolume) * Multiplier;
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, volume);
        }

        private void SetMuted()
        {
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, MinMixerVolume);
        }
    }
}
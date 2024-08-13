using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Modules.Audio
{
    public class AudioSlider : AudioSetter
    {
        private const int MinMixerVolume = -80;
        private const float Multiplier = 20f;
        private const float ZeroSound = 0f;

        [SerializeField] private Slider _slider;
        [SerializeField] private AudioMixerGroup _audioMixerGroup;
        [SerializeField] private string _mixerName;

        private bool _isMuted;
        
        public override event Action Changed;
        
        public override float Volume => _slider.value;
        public override bool IsMuted => _isMuted;

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        public override void Init(float value, bool isMuted)
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
            _slider.value = value;
            _isMuted = isMuted;
            
            if (IsMuted)
                SetMute();
        }

        private void OnValueChanged(float sliderValue)
        {
            if (sliderValue == ZeroSound)
            {
                SetMute();
                Changed?.Invoke();
                return;
            }

            float volume = Mathf.Log10(sliderValue) * Multiplier;
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, volume);
            _isMuted = false;
            Changed?.Invoke();
        }

        private void SetMute()
        {
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, MinMixerVolume);
        }
    }
}
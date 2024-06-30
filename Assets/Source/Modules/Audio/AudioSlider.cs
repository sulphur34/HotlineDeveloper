using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Modules.Audio
{
    public class AudioSlider : MonoBehaviour
    {
        private const int MinMixerVolume = -80;
        private const float Multiplier = 20f;

        [SerializeField] private Slider _slider;
        [SerializeField] private AudioMixerGroup _audioMixerGroup;
        [SerializeField] private string _mixerName;

        public float Volume => _slider.value;

        public event Action Changed;

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        public void Init(float value)
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
            _slider.value = value;
        }

        private void OnValueChanged(float sliderValue)
        {
            if (sliderValue == 0)
            {
                _audioMixerGroup.audioMixer.SetFloat(_mixerName, MinMixerVolume);
                Changed?.Invoke();
                return;
            }

            float volume = Mathf.Log10(sliderValue) * Multiplier;
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, volume);
            Changed?.Invoke();
        }
    }
}

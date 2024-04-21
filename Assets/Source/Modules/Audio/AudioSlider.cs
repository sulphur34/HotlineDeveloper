using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    private const int MinMixerVolume = -80;
    private const float Multiplier = 20f;

    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private string _mixerName;

    private void Start()
    {
        _slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(float sliderValue)
    {
        if (sliderValue == 0)
        {
            _audioMixerGroup.audioMixer.SetFloat(_mixerName, MinMixerVolume);
            return;
        }

        float volume = Mathf.Log10(sliderValue) * Multiplier;
        _audioMixerGroup.audioMixer.SetFloat(_mixerName, volume);
    }
}

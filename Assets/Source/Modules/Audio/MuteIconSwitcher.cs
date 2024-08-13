using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Audio
{
    [RequireComponent(typeof(Button))]
    public class MuteIconSwitcher : MonoBehaviour
    {
        [SerializeField] private Image _muteImage;
        [SerializeField] private Image _audioImage;
        
        private AudioSetter _musicSetter;
        private AudioSetter _soundSetter;
        private Button _button;

        public void Initialize(AudioSetter musicSetter, AudioSetter soundSetter)
        {
            _musicSetter = musicSetter;
            _soundSetter = soundSetter;
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
            SetIcon(_musicSetter.IsMuted || _soundSetter.IsMuted);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            if (_musicSetter.IsMuted || _soundSetter.IsMuted)
            {
                 SetIcon(true);
                return;
            }
            
            SetIcon(false);
        }

        private void SetIcon(bool isMuted)
        {
            _muteImage.enabled = isMuted;
            _audioImage.enabled = !isMuted;
        }
    }
}
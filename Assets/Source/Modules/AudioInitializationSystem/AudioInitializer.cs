using System;
using System.Collections;
using System.Collections.Generic;
using Modules.Audio;
using Modules.SavingsSystem;
using UnityEngine;
using VContainer;
using AudioSettings = Modules.Audio.AudioSettings;

namespace Source.Modules.AudioInitializationSystem
{
    public class AudioInitializer
    {
        private SaveSystem _saveSystem;
        private AudioSettings _audioSettings;
        private Coroutine _coroutine;

        public event Action<AudioSettings> Initialized;

        [Inject]
        private void Construct(SaveSystem saveSystem, AudioSettings audioSettings)
        {
            _saveSystem = saveSystem;
            _audioSettings = audioSettings;
        }

        private void OnDestroy()
        {
            if(_coroutine != null)
                _audioSettings.StopCoroutine(_coroutine);
        }

        public void Initialize()
        {
            _saveSystem.Load(LoadSettings);
        }

        private void LoadSettings(SaveData data)
        {
            if(_coroutine != null)
                _audioSettings.StopCoroutine(_coroutine);

            _audioSettings.StartCoroutine(LoadRoutine(data));
        }

        private IEnumerator LoadRoutine(SaveData data)
        {
            yield return null;
            AudioSettingsData audioData = data.AudioSettingsData;
            _audioSettings.MusicSetter.Init(audioData.MusicVolume, audioData.IsMuted);
            _audioSettings.SoundSetter.Init(audioData.SoundVolume, audioData.IsMuted);
            Initialized?.Invoke(_audioSettings);
        }
    }
}
using Modules.Audio;
using Modules.SavingsSystem;
using System;
using VContainer;

namespace Modules.SaveHandlers
{
    public class AudioSaveHandler : IDisposable
    {
        private readonly SaveSystem _saveSystem;
        private readonly AudioSettings _audioSettings;

        [Inject]
        public AudioSaveHandler(AudioSettings audioSettings)
        {
            _saveSystem = new SaveSystem();
            _audioSettings = audioSettings;

            _audioSettings.MusicSetter.Changed += OnMusicChanged;
            _audioSettings.SoundSetter.Changed += OnSoundChanged;
        }

        public void Dispose()
        {
            _audioSettings.MusicSetter.Changed -= OnMusicChanged;
            _audioSettings.SoundSetter.Changed -= OnSoundChanged;
        }

        private void OnMusicChanged()
        {
            _saveSystem.Save(data =>
            {
                data.AudioSettingsData.MusicVolume = _audioSettings.MusicSetter.Volume;
                data.AudioSettingsData.IsMuted = _audioSettings.MusicSetter.IsMuted;
            });
        }

        private void OnSoundChanged()
        {
            _saveSystem.Save(data =>
            {
                data.AudioSettingsData.SoundVolume = _audioSettings.SoundSetter.Volume;
                data.AudioSettingsData.IsMuted = _audioSettings.SoundSetter.IsMuted;
            });
        }
    }
}
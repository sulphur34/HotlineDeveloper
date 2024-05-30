using Modules.Audio;
using Modules.SavingsSystem;
using System;
using VContainer;

namespace Modules.SaveHandlers
{
    public class AudioSaveHandler : IDisposable
    {
        private readonly SaveSystem _saveSystem = new SaveSystem();
        private readonly AudioSettings _audioSettings;

        [Inject]
        public AudioSaveHandler(AudioSettings audioSettings)
        {
            _audioSettings = audioSettings;

            _audioSettings.MusicSlider.Changed += OnMusicChanged;
            _audioSettings.SoundSlider.Changed += OnSoundChanged;
        }

        public void Dispose()
        {
            _audioSettings.MusicSlider.Changed -= OnMusicChanged;
            _audioSettings.SoundSlider.Changed -= OnSoundChanged;
        }

        private void OnMusicChanged()
        {
            _saveSystem.Save(data =>
            {
                data.AudioSettingsData.MusicVolume = _audioSettings.MusicSlider.Volume;
            });
        }

        private void OnSoundChanged()
        {
            _saveSystem.Save(data =>
            {
                data.AudioSettingsData.SoundVolume = _audioSettings.SoundSlider.Volume;
            });
        }
    }
}
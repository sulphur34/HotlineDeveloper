using Modules.Audio;
using Modules.SavingsSystem;
using VContainer;

namespace Source.Modules.AudioInitializationSystem
{
    public class AudioInitializer
    {
        private SaveSystem _saveSystem;
        private AudioSettings _audioSettings;

        [Inject]
        private void Construct(SaveSystem saveSystem, AudioSettings audioSettings)
        {
            _saveSystem = saveSystem;
            _audioSettings = audioSettings;
        }

        public void Initialize()
        {
            _saveSystem.Load(LoadSettings);
        }

        private void LoadSettings(SaveData data)
        {
            AudioSettingsData audioData = data.AudioSettingsData;
            _audioSettings.MusicSetter.Init(audioData.MusicVolume, audioData.IsMuted);
            _audioSettings.SoundSetter.Init(audioData.MusicVolume, audioData.IsMuted);
        }
    }
}
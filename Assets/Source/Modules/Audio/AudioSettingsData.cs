using System;

namespace Modules.Audio
{
    [Serializable]
    public class AudioSettingsData
    {
        public float MusicVolume = 0.5f;
        public float SoundVolume = 0.5f;
        public bool IsMuted;
    }
}

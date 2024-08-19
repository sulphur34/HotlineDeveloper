using System;
using UnityEngine;

namespace Modules.Audio
{
    [Serializable]
    public class AudioSettingsData
    {
        private const float MaxVolume = 1f;
        private const float MinVolume = 0f;

        public float MusicVolume { get; private set; } = 1;
        public float SoundVolume { get; private set; } = 1;

        public void SetMusicVolume(float value)
        {
            MusicVolume = Mathf.Clamp(value, MinVolume, MaxVolume);
        }

        public void SetSoundVolume(float value)
        {
            SoundVolume = Mathf.Clamp(value, MinVolume, MaxVolume);
        }
    }
}
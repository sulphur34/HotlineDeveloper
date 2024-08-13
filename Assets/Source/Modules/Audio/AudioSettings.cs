using UnityEngine;

namespace Modules.Audio
{
    public class AudioSettings : MonoBehaviour
    {
        [field: SerializeField] public AudioSetter MusicSetter { get; private set; }

        [field: SerializeField] public AudioSetter SoundSetter { get; private set; }
    }
}
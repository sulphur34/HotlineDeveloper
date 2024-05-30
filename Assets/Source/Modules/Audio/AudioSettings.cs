using UnityEngine;

namespace Modules.Audio
{
    public class AudioSettings : MonoBehaviour
    {
        [field: SerializeField] public AudioSlider MusicSlider { get; private set; }

        [field: SerializeField] public AudioSlider SoundSlider { get; private set; }
    }
}
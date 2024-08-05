using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using UnityEngine;

namespace Modules.Audio
{
    [RequireComponent(typeof(SourceAudio))]
    internal class SoundHandler : MonoBehaviour
    {
        private SourceAudio _source;

        protected virtual void Awake()
        {
            _source = GetComponent<SourceAudio>();
        }

        protected void Play(AudioDataProperty audioName)
        {
            _source.PlayOneShot(audioName);
        }
    }
}
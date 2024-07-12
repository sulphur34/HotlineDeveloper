using System;
using Plugins.Audio.Core;
using UnityEngine;

namespace Modules.Audio
{
    [RequireComponent(typeof(SourceAudio))]
    public class SoundHandler : MonoBehaviour
    {
        private SourceAudio _source;

        protected virtual void Awake()
        {
            _source = GetComponent<SourceAudio>();
        }

        protected void Play(AudioSourceNames audioName)
        {
            _source.Play(audioName.ToString());
        }
    }
}
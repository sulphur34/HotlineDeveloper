using System;
using UnityEngine;

namespace Modules.Audio
{
    public abstract class AudioSetter : MonoBehaviour
    {
        public abstract float Volume { get; }
        public abstract bool IsMuted { get; }

        public abstract event Action Changed;
            
        public abstract void Init(float initialValue, bool IsMuted);
    }
}
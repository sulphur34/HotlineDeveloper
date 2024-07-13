using System.Diagnostics;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using UnityEngine;
using VContainer;

namespace Modules.Audio
{
    [RequireComponent(typeof(SourceAudio))]
    public class MusicHandler : MonoBehaviour
    {
        private static MusicHandler _instance;

        [SerializeField] private AudioDataProperty[] _levelsMusicNames;
        [SerializeField] private AudioDataProperty _mainMenuMusicName;

        private SourceAudio _sourceAudio;

        public static MusicHandler Instance => _instance;
        public bool IsLevelMusicPlaying { get; private set; }
        
        [Inject]
        public void Construct()
        {
            if (_instance == null)
            {
                _instance = this;
                _sourceAudio = GetComponent<SourceAudio>();
                DontDestroyOnLoad(this.gameObject);
            }
            else if (_instance != this)
            {
                Destroy(_instance);
            }
        }

        public void OnMenuLoad()
        {
            IsLevelMusicPlaying = false;
            Stop();
            PlayMenu();
        }

        public void OnLevelLoad()
        {
            if (IsLevelMusicPlaying)
                return;
            
            Stop();
            PlayRandom();
            _sourceAudio.OnFinished += PlayRandom;
            IsLevelMusicPlaying = true;
        }

        private void PlayRandom()
        {
            int index = Random.Range(0, _levelsMusicNames.Length);
            _sourceAudio.Play(_levelsMusicNames[index]);
        }
        
        private void PlayMenu()
        {
            _sourceAudio.Loop = true;
            _sourceAudio.Play(_mainMenuMusicName);
        }

        private void Stop()
        {
            _sourceAudio.OnFinished -= PlayRandom;
            _sourceAudio.Stop();
        }
    }
}
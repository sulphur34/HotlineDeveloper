using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using UnityEngine;

namespace Modules.Audio
{
    [RequireComponent(typeof(SourceAudio))]
    internal class MusicHandler : MonoBehaviour
    {
        private static MusicHandler _instance;

        [SerializeField] private AudioDataProperty[] _levelsMusicNames;
        [SerializeField] private AudioDataProperty _mainMenuMusicName;

        private SourceAudio _sourceAudio;

        internal static MusicHandler Instance => _instance;

        private bool IsLevelMusicPlaying { get; set; }

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else if (_instance != this)
                Destroy(_instance.gameObject);

            _sourceAudio = GetComponent<SourceAudio>();
            DontDestroyOnLoad(gameObject);
        }

        internal void OnMenuLoad()
        {
            IsLevelMusicPlaying = false;
            Stop();
            PlayMenu();
        }

        internal void OnLevelLoad()
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
            _sourceAudio.Stop();
            _sourceAudio.Loop = true;
            _sourceAudio.Time = 0;
            _sourceAudio.Play(_mainMenuMusicName);
        }

        private void Stop()
        {
            _sourceAudio.Loop = false;
            _sourceAudio.OnFinished -= PlayRandom;
            _sourceAudio.Stop();
        }
    }
}
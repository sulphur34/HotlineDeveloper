using UnityEngine;

namespace Modules.Audio
{
    internal class LevelMusicTrigger : MonoBehaviour
    {
        private void Start()
        {
            MusicHandler.Instance.OnLevelLoad();
        }
    }
}
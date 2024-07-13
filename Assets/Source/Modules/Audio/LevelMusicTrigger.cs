using UnityEngine;

namespace Modules.Audio
{
    public class LevelMusicTrigger : MonoBehaviour
    {
        private void Awake()
        {
            MusicHandler.Instance.OnLevelLoad();
        }
    }
}
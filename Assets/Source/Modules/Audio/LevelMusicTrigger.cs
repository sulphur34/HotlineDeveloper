using UnityEngine;

namespace Modules.Audio
{
    public class LevelMusicTrigger : MonoBehaviour
    {
        private void Start()
        {
            MusicHandler.Instance.OnLevelLoad();
        }
    }
}
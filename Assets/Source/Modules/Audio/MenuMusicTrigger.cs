using UnityEngine;

namespace Modules.Audio
{
    internal class MenuMusicTrigger : MonoBehaviour
    {
        private void Start()
        {
            MusicHandler.Instance.OnMenuLoad();
        }
    }
}
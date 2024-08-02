using Plugins.Audio.Core;
using UnityEngine;

namespace Modules.Audio
{
    public class MenuMusicTrigger : MonoBehaviour
    {
        private void Start()
        {
            MusicHandler.Instance.OnMenuLoad();
        }
    }
}
using System;
using UnityEngine;

namespace Modules.Audio
{
    public class MenuMusicTrigger : MonoBehaviour
    {
        private void Awake()
        {
            MusicHandler.Instance.OnMenuLoad();
        }
    }
}
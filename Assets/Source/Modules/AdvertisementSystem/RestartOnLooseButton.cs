using Modules.AdvertisementSystem;
using Modules.FocusSystem;
using UnityEngine;

namespace Modules.AdvertisementSystem
{
    public class RestartOnLooseButton : RestartLevelButton
    {
        [SerializeField] private VideoAD _videoAD;
        [SerializeField] private bool HasAD = true;

        protected override void MakeOnClick()
        {
#if UNITY_EDITOR
            ReloadLevel();
            return;
#endif

            // PauseSetter.Enable();
            if (HasAD)
            {
                _videoAD.Closed += ReloadLevel;
                _videoAD.ShowInter();
            }
            else
            {
                ReloadLevel();
            }
        }

        private void ReloadLevel()
        {
            base.MakeOnClick();
            _videoAD.Closed -= ReloadLevel;
        }
    }
}
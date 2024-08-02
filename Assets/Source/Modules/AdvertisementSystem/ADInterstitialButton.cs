using UnityEngine;
using UnityEngine.UI;

namespace Source.Modules.AdvertisementSystem
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(VideoAD))]
    public class ADInterstitialButton : ADButton
    {
        protected override void OnButtonClick() { }

        protected override void OnVideoClose() { }

        protected override void ShowAD()
        {
#if UNITY_EDITOR
            return;
#endif
            VideoAD.ShowInter();
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Modules.AdvertisementSystem
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(VideoAD))]
    public abstract class ADRewardedButton : ADButton
    {
        protected override void Awake()
        {
            base.Awake();
            VideoAD.RewardGained += OnRewardGained;
        }

        protected override void OnDestroy()
        {
            if (VideoAD != null)
                VideoAD.RewardGained -= OnRewardGained;

            base.OnDestroy();
        }

        protected override void ShowAD()
        {
#if UNITY_EDITOR
            OnRewardGained();
            OnVideoClose();
            return;
#endif
            VideoAD.ShowRewarded();
        }

        protected abstract void OnRewardGained();
    }
}
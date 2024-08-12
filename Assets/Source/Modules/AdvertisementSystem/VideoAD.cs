using System;
using Modules.AdvertisementSystem;
using UnityEngine;
using VContainer;

namespace Modules.AdvertisementSystem
{
    public class VideoAD : MonoBehaviour
    {
        private PauseSetter _pauseSetter;
        
        public event Action RewardGained;
        public event Action Closed;

        [Inject]
        public void Construct(PauseSetter pauseSetter)
        {
            _pauseSetter = pauseSetter;
        }

        public void ShowRewarded()
        {
            Agava.YandexGames.VideoAd.Show(OnOpenCallBack, OnRewardCallBack, OnCloseCallBack);
        }

        public void ShowInter()
        {
            Agava.YandexGames.InterstitialAd.Show(OnOpenCallBack, OnCloseCallBack);
        }

        private void OnOpenCallBack()
        {
            _pauseSetter.Enable();
        }

        private void OnRewardCallBack()
        {
            RewardGained?.Invoke();
        }

        private void OnCloseCallBack()
        {
            Closed?.Invoke();
            _pauseSetter.Disable();
        }

        private void OnCloseCallBack(bool isShown)
        {
            OnCloseCallBack();
        }
    }
}
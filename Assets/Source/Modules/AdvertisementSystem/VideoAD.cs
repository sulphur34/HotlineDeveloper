using System;
using Modules.PauseMenu;
using UnityEngine;
using VContainer;

namespace Source.Modules.AdvertisementSystem
{
    public class VideoAD : MonoBehaviour
    {
        private PauseSetter _pauseSetter;
        
        public event Action RewardGained;
        public event Action Closed;

        public bool IsPlaying { get; private set; }

        private void Awake()
        {
            IsPlaying = false;
        }

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
            IsPlaying = true;
            _pauseSetter.Enable();
        }

        private void OnRewardCallBack()
        {
            RewardGained?.Invoke();
        }

        private void OnCloseCallBack()
        {
            IsPlaying = false;
            Closed?.Invoke();
            _pauseSetter.Disable();
        }

        private void OnCloseCallBack(bool isShown)
        {
            OnCloseCallBack();
        }
    }
}
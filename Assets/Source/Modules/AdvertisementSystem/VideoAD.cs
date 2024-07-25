using System;
using Plugins.Audio.Core;
using UnityEngine;

namespace Source.Modules.AdvertisementSystem
{
    public class VideoAD : MonoBehaviour
    {
        public event Action RewardGained;
        public event Action Closed;

        public bool IsPlaying { get; private set; }

        private void Awake()
        {
            IsPlaying = false;
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
            Time.timeScale = 0;
            AudioPauseHandler.Instance.PauseAudio();
        }

        private void OnRewardCallBack()
        {
            RewardGained?.Invoke();
        }

        private void OnCloseCallBack()
        {
            IsPlaying = false;
            Time.timeScale = 1;
            AudioPauseHandler.Instance.UnpauseAudio();
            Closed?.Invoke();
        }

        private void OnCloseCallBack(bool isShown)
        {
            OnCloseCallBack();
        }
    }
}
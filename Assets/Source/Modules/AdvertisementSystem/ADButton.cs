using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.AdvertisementSystem
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(VideoAD))]
    public abstract class ADButton : MonoBehaviour
    {
        protected VideoAD VideoAD { get; private set; }

        protected virtual void Awake()
        {
            VideoAD = GetComponent<VideoAD>();
            Button button = GetComponent<Button>();
            button.onClick.AddListener(ShowAD);
            button.onClick.AddListener(OnButtonClick);
            VideoAD.Closed += OnVideoClose;
        }

        protected virtual void OnDestroy()
        {
            if (VideoAD != null)
                VideoAD.Closed -= OnVideoClose;
        }

        protected abstract void ShowAD();

        protected abstract void OnButtonClick();

        protected abstract void OnVideoClose();
    }
}
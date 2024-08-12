using System;
using Agava.WebUtility;
using Modules.AdvertisementSystem;
using UnityEngine;
using VContainer;

namespace Source.Modules.FocusSystem
{
    public class Focus : IDisposable
    {
        private readonly PauseSetter _pauseSetter;

        [Inject]
        public Focus(PauseSetter pauseSetter)
        {
            _pauseSetter = pauseSetter;
            Application.focusChanged += SetPauseApp;
            WebApplication.InBackgroundChangeEvent += SetPauseWeb;
        }

        public void Dispose()
        {
            Application.focusChanged -= SetPauseApp;
            WebApplication.InBackgroundChangeEvent -= SetPauseWeb;
        }

        private void SetPauseWeb(bool isBackground)
        {
            if (isBackground)
            {
                _pauseSetter.Enable();
            }
            else
            {
                _pauseSetter.Disable();
            }
        }

        private void SetPauseApp(bool inApp)
        {
            if (!inApp)
            {
                _pauseSetter.Enable();
            }
            else
            {
                _pauseSetter.Disable();
            }
        }
    }
}
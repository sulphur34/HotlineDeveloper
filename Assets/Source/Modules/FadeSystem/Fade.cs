using System;
using DG.Tweening;
using Modules.SceneLoaderSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.FadeSystem
{
    public class Fade : MonoBehaviour, IOperationBeforeLoading
    {
        private const float FullAlpha = 1.0f;
        private const float ZeroAlpha = 0.0f;

        [SerializeField] private Image _image;
        [SerializeField] private float _waitTime;

        public event Action<IOperationBeforeLoading> Executed;

        public void In()
        {
            _image.raycastTarget = true;
            SetAlpha(ZeroAlpha);
            _image.DOFade(1, _waitTime).OnComplete(() => Executed?.Invoke(this));
        }

        public void Out()
        {
            _image.raycastTarget = false;
            SetAlpha(FullAlpha);
            _image.DOFade(0, _waitTime).OnComplete(() => Executed?.Invoke(this));
        }

        private void SetAlpha(float value)
        {
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, value);
        }
    }
}
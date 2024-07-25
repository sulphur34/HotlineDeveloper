using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Source.Modules.GUISystem
{
    public class UILoopFader : MonoBehaviour
    {
        [SerializeField] private float _startTransparentState = 1f;
        [SerializeField] private float _endTransparentState = 0f;
        [SerializeField] private float _awaitTime = 1f;
        [SerializeField] private float _duration = 0.5f;
        
        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            Animate();
        }

        protected void Animate()
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(_image.DOFade(_endTransparentState, _duration))
                .AppendInterval(_awaitTime)
                .Append(_image.DOFade(_startTransparentState, _duration))
                .AppendInterval(_awaitTime)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Modules.ScoreSystem
{
    public class UILoopFader : MonoBehaviour
    {
        [SerializeField] private float _startTransparentState = 1f;
        [SerializeField] private float _endTransparentState = 0f;
        [SerializeField] private float _awaitTime = 1f;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private float _awaitChangeFactor = 1f;
        [SerializeField] private float _durationChangeFactor = 1f;
        
        private Image _image;
        private Sequence _sequence;

        private void Start()
        {
            _image = GetComponent<Image>();
            Animate();
        }

        protected void Animate()
        {
            if(_sequence != null)
                _sequence.Kill();
            
            _sequence = DOTween.Sequence();
            _sequence.Append(_image.DOFade(_endTransparentState, _duration))
                .AppendInterval(_awaitTime)
                .Append(_image.DOFade(_startTransparentState, _duration))
                .AppendInterval(_awaitTime)
                .SetLoops(-1, LoopType.Restart)
                .OnStepComplete(OnLoopComplete);
        }

        protected void OnLoopComplete()
        {
            _awaitTime *= _awaitChangeFactor;
            _duration *= _durationChangeFactor;
            
            Animate();
        }
    }
}
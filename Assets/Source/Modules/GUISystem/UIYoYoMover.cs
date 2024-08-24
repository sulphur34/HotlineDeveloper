using System;
using DG.Tweening;
using UnityEngine;

namespace Modules.GUISystem
{
    public class UIYoYoMover : MonoBehaviour
    {
        [SerializeField] private float _moveDistance;
        [SerializeField] private float _animationDuration;
        [SerializeField] private bool _isVertical;

        private RectTransform _transform;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();

            if (_transform == null)
            {
                throw new NullReferenceException(
                    "RectTransform of UI element is null. Please set it in the inspector.");
            }

            if (_isVertical)
                AnimateVertical();
            else
                AnimateHorizontal();
        }

        private void AnimateHorizontal()
        {
            _transform.DOAnchorPosX(_transform.anchoredPosition.x - _moveDistance, _animationDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }

        private void AnimateVertical()
        {
            _transform.DOAnchorPosY(_transform.anchoredPosition.y - _moveDistance, _animationDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }
    }
}
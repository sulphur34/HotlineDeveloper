using DG.Tweening;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField] private float _moveDistance;
    [SerializeField] private float _animationDuration;
    [SerializeField] private bool _isVertical;

    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        
        if (_isVertical)
        {
            _transform.DOAnchorPosY(_transform.anchoredPosition.y - _moveDistance, _animationDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }
        else
        {
            _transform.DOAnchorPosX(_transform.anchoredPosition.x - _moveDistance, _animationDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }
    }
}
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Modules.ScoreSystem
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreLabel : MonoBehaviour
    {
        [SerializeField] private Vector3 _maxScale;
        [SerializeField] private float _animationDuration;

        private TextMeshProUGUI _textMeshPro;
        private RectTransform _rectTransform;
        private Tween _tween;
        private Quaternion _defaultRotation;

        public void Initialize()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            _rectTransform = GetComponent<RectTransform>();
            _defaultRotation = _rectTransform.rotation;
        }
        
        public void SetValue(uint value)
        {
            _textMeshPro.text = value.ToString();
            _rectTransform.DOKill();
            _rectTransform.rotation = _defaultRotation;
            _rectTransform.DOShakeRotation(0.5f,new Vector3(0,0,50), 10, 90);
        }
    }
}
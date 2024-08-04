using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Modules.GUISystem
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    internal class ScoreLabel : MonoBehaviour
    {
        [SerializeField] private Vector3 _shakeRotation = new Vector3(0,0,50);
        [SerializeField] private float _duration = 0.5f;

        private TextMeshProUGUI _textMeshPro;
        private RectTransform _rectTransform;
        private Tween _tween;
        private Quaternion _defaultRotation;

        internal void Initialize()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            _rectTransform = GetComponent<RectTransform>();
            _defaultRotation = _rectTransform.rotation;
        }
        
        internal void SetValue(uint value)
        {
            _textMeshPro.text = value.ToString();
            _rectTransform.DOKill();
            _rectTransform.rotation = _defaultRotation;
            _rectTransform.DOShakeRotation(_duration,_shakeRotation, 10, 90);
        }
    }
}
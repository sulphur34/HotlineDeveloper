using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Modules.GUISystem
{
    [RequireComponent(typeof(RectTransform))]
    public class UIShaker : UITransformAnimator
    {
        private readonly int _vibrato = 0;
        private readonly float _offsetZ = 0f;
        private readonly float _randomness = 60f;

        [SerializeField] private float _shakeDuration = 0.1f;
        [SerializeField] private float _shakeStrength = 1f;

        private float RandomStrength => Random.Range(-_shakeStrength, _shakeStrength);

        protected override void Animate()
        {
            Vector3 randomOffset = new (RandomStrength, RandomStrength, _offsetZ);
            Transform.DOShakePosition(
                    _shakeDuration,
                    randomOffset,
                    _vibrato,
                    _randomness,
                    false,
                    false,
                    ShakeRandomnessMode.Harmonic)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}
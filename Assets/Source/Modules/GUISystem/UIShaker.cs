using DG.Tweening;
using Modules.GUISystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Modules.GUISystem
{
    [RequireComponent(typeof(RectTransform))]
    public class UIShaker : UITransformAnimator
    {
        [SerializeField] private float _shakeDuration = 0.1f;
        [SerializeField] private float _shakeStrength = 1f;

        private float RandomStrength => Random.Range(-_shakeStrength, _shakeStrength);

        protected override void Animate()
        {
            Vector3 randomOffset = new Vector3(RandomStrength, RandomStrength, 0f);
            Transform.DOShakePosition(_shakeDuration, randomOffset, 0, 60f, false, false, ShakeRandomnessMode.Harmonic)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}
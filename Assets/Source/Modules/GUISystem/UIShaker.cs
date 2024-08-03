using DG.Tweening;
using Modules.ScoreSystem;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(RectTransform))]
public class UIShaker : UITransformAnimator
{
    [SerializeField] private float shakeDuration = 0.1f;
    [SerializeField] private float shakeStrength = 1f;
    
    private float _randomStrength => Random.Range(-shakeStrength, shakeStrength);
    
    protected override void Animate()
    {
        Vector3 randomOffset = new Vector3(_randomStrength, _randomStrength, 0f);
        Transform.DOShakePosition(shakeDuration, randomOffset, 0, 60f,false, false,ShakeRandomnessMode.Harmonic).SetLoops(-1,LoopType.Restart);
    }
}

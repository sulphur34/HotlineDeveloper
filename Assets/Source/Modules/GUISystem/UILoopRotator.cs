using DG.Tweening;
using UnityEngine;

namespace Modules.GUISystem
{
    public class UILoopRotator : UITransformAnimator
    {
        [SerializeField] private float _rotationDuration = 1f;
        [SerializeField] private float _rotationSpeed = 9f;

        protected override void Animate()
        {
            Vector3 rotation = new Vector3(0f, 0f, _rotationSpeed);
            Transform.DORotate(rotation, _rotationDuration).SetLoops(-1, LoopType.Incremental);
        }
    }
}
using DG.Tweening;
using UnityEngine;

namespace Modules.ScoreSystem
{
    public class UILoopRotator : UITransformAnimator
    {
        [SerializeField] private float _rotationDuration = 1f;
        [SerializeField] private float _rotationSpeed = 9f;
        
        private Vector3 _rotation; 
    
        protected override void Animate()
        {
            _rotation = new Vector3(0f, 0f, _rotationSpeed);
            Transform.DORotate(_rotation, _rotationDuration).SetLoops(-1, LoopType.Incremental);
        }
    }
}
using System.Collections;
using System.Threading;
using UnityEngine;


namespace Modules.AnimationSystem
{
    internal class AnimatorController
    {
        private readonly Animator _animator;
        private readonly AnimationController _animationController;
        private readonly AnimatorIndexer _animatorIndexer;
        private readonly Transform _transform;
        private readonly CancellationTokenSource _cancellationTokenSource;

        private Coroutine _coroutine; 
        private Vector3 _oldPosition;

        internal AnimatorController(Animator animator, Transform transform, AnimationController animationController)
        {
            _animatorIndexer = new AnimatorIndexer();
            _animator = animator;
            _transform = transform;
            _animationController = animationController;
        }

        internal void Activate()
        {
            _animator.enabled = true;
            _coroutine = _animationController.StartCoroutine(TrackingSpeed());
        }

        internal void Deactivate()
        {
            _animationController.StopCoroutine(_coroutine);
            _animator.enabled = false;
        }

        internal void AnimateTwoHandsAttack()
        {
            _animator.SetTrigger(_animatorIndexer.TwoHandsAttackIndex);
        }

        internal void AnimateOneHandAttack()
        {
            _animator.SetTrigger(_animatorIndexer.OneHandAttackIndex);
        }

        internal void AnimateBareHandsAttack()
        {
            _animator.SetTrigger(_animatorIndexer.BareHandsAttackIndex);
        }

        private IEnumerator TrackingSpeed()
        {
            while (true)
            {
                float distance = Vector3.Magnitude(_transform.position - _oldPosition);
                _animator.SetFloat(_animatorIndexer.SpeedIndex, distance);
                _oldPosition = _transform.position;
                yield return null;
            }
        }
    }
}
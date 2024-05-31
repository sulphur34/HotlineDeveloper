using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace Source.Game.Scripts.Animations
{
    internal class AnimatorController
    {
        private const string TwoHandsAttackName = "TwoHandsAttack";
        private const string OneHandAttackName = "OneHandAttack";
        private const string BareHandsAttack = "BareHandsAttack";
        private const string SpeedName = "Speed";

        private readonly int _twoHandsAttackIndex;
        private readonly int _oneHandAttackIndex;
        private readonly int _bareHandsAttackIndex;
        private readonly int _speedIndex;
        private readonly Animator _animator;
        private readonly Transform _transform;
        private readonly CancellationTokenSource _cancellationTokenSource;
        
        private Vector3 _oldPosition;

        public AnimatorController(Animator animator, Transform transform, CancellationTokenSource cancellationTokenSource)
        {
            _twoHandsAttackIndex = Animator.StringToHash(TwoHandsAttackName);
            _bareHandsAttackIndex = Animator.StringToHash(BareHandsAttack);
            _oneHandAttackIndex = Animator.StringToHash(OneHandAttackName);
            _speedIndex = Animator.StringToHash(SpeedName);
            _animator = animator;
            _transform = transform;
        }

        public void Activate()
        {
            _animator.enabled = true;
            TrackingSpeed(_cancellationTokenSource.Token);
        }

        public void Deactivate()
        {
            _cancellationTokenSource.Cancel();
            _animator.enabled = false;
        }

        public void AnimateTwoHandsAttack()
        {
            _animator.SetTrigger(_twoHandsAttackIndex);
        }

        public void AnimateOneHandAttack()
        {
            _animator.SetTrigger(_oneHandAttackIndex);
        }

        public void AnimateBareHandsAttack()
        {
            _animator.SetTrigger(_bareHandsAttackIndex);
        }
        
        private async UniTask TrackingSpeed(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                float distance = Vector3.Magnitude(_transform.position - _oldPosition);
                _animator.SetFloat(_speedIndex, distance);
                _oldPosition = _transform.position;
                await UniTask.Yield(PlayerLoopTiming.Update);
            }
        }
    }
}
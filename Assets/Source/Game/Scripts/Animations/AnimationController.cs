using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.DamageSystem;
using UnityEngine;

namespace Source.Game.Scripts.Animations
{
    [RequireComponent(typeof(ConstrainsController), typeof(RagdollController))]
    public class AnimationController : MonoBehaviour
    {
        public const string SpeedName = "Speed";

        private DamageReceiverView _damageReceiverView;
        private ConstrainsController _constrainsController;
        private RagdollController _ragdollController;
        private Transform _transform;
        private Animator _animator;
        private int _speedIndex;
        private Vector3 _oldPosition;
        private CancellationTokenSource _cancellationTokenSource;

        private void Awake()
        {
            _transform = transform;
            _oldPosition = _transform.position;
            _animator = GetComponent<Animator>();
            _cancellationTokenSource = new CancellationTokenSource();
            _speedIndex = Animator.StringToHash(SpeedName);
            _constrainsController = GetComponent<ConstrainsController>();
            _ragdollController = GetComponent<RagdollController>();
            _damageReceiverView = GetComponent<DamageReceiverView>();
            _damageReceiverView.FallenDown += OnFallDown;
            _damageReceiverView.StoodUp += OnStandUp;
            OnStandUp();
        }

        private void OnEnable()
        {
            TrackingSpeed(_cancellationTokenSource.Token);
        }

        private void OnDisable()
        {
            _cancellationTokenSource?.Cancel();
            _damageReceiverView.FallenDown -= OnFallDown;
            _damageReceiverView.StoodUp -= OnStandUp;
        }

        private void OnFallDown()
        {
            _animator.enabled = false;
            _constrainsController.Deactivate();
            _ragdollController.Activate();
        }

        private void OnStandUp()
        {
            _animator.enabled = true;
            _ragdollController.Deactivate();
            _constrainsController.Activate();
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
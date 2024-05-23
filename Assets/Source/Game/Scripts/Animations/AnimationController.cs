using Modules.DamageSystem;
using UnityEngine;

namespace Source.Game.Scripts.Animations
{
    [RequireComponent(typeof(ConstrainsController), typeof(RagdollController))]
    public class AnimationController : MonoBehaviour
    {
        private DamageReceiverView _damageReceiverView;
        private ConstrainsController _constrainsController;
        private RagdollController _ragdollController;
        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _constrainsController = GetComponent<ConstrainsController>();
            _ragdollController = GetComponent<RagdollController>();
            _damageReceiverView = GetComponent<DamageReceiverView>();
            _damageReceiverView.FallenDown += OnFallDown;
            _damageReceiverView.StoodUp += OnStandUp;
            OnStandUp();
        }

        private void OnDisable()
        {
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
    }
}
using System.Threading;
using UnityEngine;

namespace Source.Game.Scripts.Animations
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private ConstraintsData _constraintsData;
        [SerializeField] private RagdollJointData[] _ragdollJointsData;

        private ConstrainsController _constrainsController;
        private RagdollController _ragdollController;
        private AnimatorController _animatorController;
        private Transform _transform;
        private Animator _animator;
        private CancellationTokenSource _cancellationTokenSource;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _transform = transform;
            _cancellationTokenSource = new CancellationTokenSource();
            _constrainsController = new ConstrainsController(_constraintsData);
            _ragdollController = new RagdollController(_ragdollJointsData);
            _animatorController = new AnimatorController(_animator, _transform, _cancellationTokenSource);
            _animatorController.Activate();
        }

        private void OnDisable()
        {
            _cancellationTokenSource?.Cancel();
        }

        public void FallDown()
        {
            Unequip();
            _animatorController.Deactivate();
            _ragdollController.Activate();
        }

        public void StandUp()
        {
            _animatorController.Activate();
            _ragdollController.Deactivate();
        }

        public void AttackMelee()
        {
            if(_constrainsController.IsTwoHanded)
                _animatorController.AnimateTwoHandsAttack();
            else
                _animatorController.AnimateOneHandAttack();
        }

        public void AttackBareHands()
        {
            _animatorController.AnimateBareHandsAttack();
        }

        public void PickMelee(Transform rightHand, Transform leftHand)
        {
            _constrainsController.ActivateMelee(rightHand, leftHand);
        }

        public void PickRange(Transform rightHand, Transform leftHand)
        {
            _constrainsController.ActivateRange(rightHand, leftHand);
        }

        public void Unequip()
        {
            _constrainsController.ClearAll();
        }
    }
}
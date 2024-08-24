using System.Collections;
using UnityEngine;

namespace Modules.AnimationSystem
{
    public class AnimationController : MonoBehaviour
    {
        private readonly float _bodyFallDelay = 2f;

        [SerializeField] private ConstraintsData _constraintsData;
        [SerializeField] private RagdollJointData[] _ragdollJointsData;
        [SerializeField] private Transform _hipBonePosition;

        private ConstrainsController _constrainsController;
        private RagdollController _ragdollController;
        private AnimatorController _animatorController;
        private Transform _transform;
        private WaitForSeconds _waitForSeconds;

        private void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_bodyFallDelay);
            Animator animator = GetComponent<Animator>();
            _transform = transform;
            _constrainsController = new ConstrainsController(_constraintsData);
            _ragdollController = new RagdollController(_ragdollJointsData);
            _animatorController = new AnimatorController(animator, _transform, this);
            _animatorController.Activate();
        }

        private void OnDisable()
        {
            _animatorController.Deactivate();
        }

        public void FallDown()
        {
            Unequip();
            _animatorController.Deactivate();
            _ragdollController.Activate();
            StartCoroutine(WaitingBodyFall());
        }

        public void StandUp()
        {
            _transform.position = _hipBonePosition.position;
            _ragdollController.Deactivate();
            _animatorController.Activate();
        }

        public void AttackMelee()
        {
            if (_constrainsController.IsTwoHanded)
            {
                _animatorController.AnimateTwoHandsAttack();
            }
            else
            {
                _animatorController.AnimateOneHandAttack();
            }
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

        private IEnumerator WaitingBodyFall()
        {
            yield return _waitForSeconds;
            _ragdollController.Deactivate();
        }
    }
}
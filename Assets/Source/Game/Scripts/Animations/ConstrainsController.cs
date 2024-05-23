using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Source.Game.Scripts.Animations
{
    public class ConstrainsController : MonoBehaviour
    {
        [SerializeField] private TwoBoneIKConstraint[] _twoBoneIKConstraints;
        [SerializeField] private IKFootSolver[] _ikFootSolvers;

        public void Activate()
        {
            SetStatus(true);
        }

        public void Deactivate()
        {
            SetStatus(false);
        }

        private void SetStatus(bool isActive)
        {
            foreach (TwoBoneIKConstraint twoBoneIKConstraint in _twoBoneIKConstraints)
            {
                twoBoneIKConstraint.weight = isActive ? 1 : 0;
            }

            foreach (IKFootSolver ikFootSolver in _ikFootSolvers)
            {
                ikFootSolver.enabled = isActive;
            }
        }
    }
}
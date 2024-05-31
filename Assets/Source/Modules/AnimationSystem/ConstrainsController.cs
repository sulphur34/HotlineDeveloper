using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Source.Game.Scripts.Animations
{
    internal class ConstrainsController
    {
        private ConstraintsData _constraintsData;

        public ConstrainsController(ConstraintsData constraintsData)
        {
            _constraintsData = constraintsData;
        }

        public bool IsTwoHanded { get; private set; }

        public void ActivateRange(Transform _rightPlaceholder, Transform _leftPlaceholder)
        {
            _constraintsData.RangeRig.weight = 1f;
            _constraintsData.RightHandRange.data.target = _rightPlaceholder;

            if (_leftPlaceholder != null)
                _constraintsData.LeftHandRange.data.target = _leftPlaceholder;

            _constraintsData.RigBuilder.Build();
        }

        public void ActivateMelee(Transform _rightPlaceholder, Transform _leftPlaceholder)
        {
            _constraintsData.MeleeRig.weight = 1f;
            _constraintsData.RightHandMelee.data.constrainedObject = _rightPlaceholder;

            if (_leftPlaceholder != null)
            {
                _constraintsData.LeftHandMelee.data.target = _leftPlaceholder;
                IsTwoHanded = true;
            }
            else
            {
                IsTwoHanded = false;
            }

            _constraintsData.RigBuilder.Build();
        }

        public void ClearAll()
        {
            _constraintsData.RangeRig.weight = 0f;
            _constraintsData.MeleeRig.weight = 0f;
            _constraintsData.RightHandRange.data.target = null;
            _constraintsData.LeftHandRange.data.target = null;
            _constraintsData.LeftHandMelee.data.target = null;
            _constraintsData.RightHandMelee.data.constrainedObject = null;
            _constraintsData.RigBuilder.Build();
        }
    }
}
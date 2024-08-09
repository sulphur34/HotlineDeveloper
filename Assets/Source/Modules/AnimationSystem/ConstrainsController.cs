using UnityEngine;

namespace Modules.AnimationSystem
{
    internal class ConstrainsController
    {
        private readonly ConstraintsData _constraintsData;

        internal ConstrainsController(ConstraintsData constraintsData)
        {
            _constraintsData = constraintsData;
        }

        internal bool IsTwoHanded { get; private set; }

        internal void ActivateRange(Transform _rightPlaceholder, Transform _leftPlaceholder)
        {
            _constraintsData.RangeRig.weight = 1f;
            _constraintsData.RightHandRange.data.target = _rightPlaceholder;

            if (_leftPlaceholder != null)
                _constraintsData.LeftHandRange.data.target = _leftPlaceholder;

            _constraintsData.RigBuilder.Build();
        }

        internal void ActivateMelee(Transform _rightPlaceholder, Transform _leftPlaceholder)
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

        internal void ClearAll()
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
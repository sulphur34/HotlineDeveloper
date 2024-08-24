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

        internal void ActivateRange(Transform rightPlaceholder, Transform leftPlaceholder)
        {
            _constraintsData.RangeRig.weight = 1f;
            _constraintsData.RightHandRange.data.target = rightPlaceholder;

            if (leftPlaceholder != null)
                _constraintsData.LeftHandRange.data.target = leftPlaceholder;

            _constraintsData.RigBuilder.Build();
        }

        internal void ActivateMelee(Transform rightPlaceholder, Transform leftPlaceholder)
        {
            _constraintsData.MeleeRig.weight = 1f;
            _constraintsData.RightHandMelee.data.constrainedObject = rightPlaceholder;

            if (leftPlaceholder != null)
            {
                _constraintsData.LeftHandMelee.data.target = leftPlaceholder;
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
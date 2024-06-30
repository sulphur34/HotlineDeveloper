using System;
using UnityEngine.Animations.Rigging;

namespace Source.Game.Scripts.Animations
{
    [Serializable]
    internal class ConstraintsData
    {
        public RigBuilder RigBuilder;
        public Rig RangeRig;
        public TwoBoneIKConstraint RightHandRange;
        public TwoBoneIKConstraint LeftHandRange;
        public Rig MeleeRig;
        public MultiParentConstraint RightHandMelee;
        public TwoBoneIKConstraint LeftHandMelee;
    }
}
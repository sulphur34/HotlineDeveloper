using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Modules.AnimationSystem
{
    [Serializable]
    internal class ConstraintsData
    {
        [field: SerializeField] public RigBuilder RigBuilder { get; private set; }
        [field: SerializeField] public Rig RangeRig { get; private set; }
        [field: SerializeField] public TwoBoneIKConstraint RightHandRange { get; private set; }
        [field: SerializeField] public TwoBoneIKConstraint LeftHandRange { get; private set; }
        [field: SerializeField] public Rig MeleeRig { get; private set; }
        [field: SerializeField] public MultiParentConstraint RightHandMelee { get; private set; }
        [field: SerializeField] public TwoBoneIKConstraint LeftHandMelee { get; private set; }
    }
}
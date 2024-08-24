using System;
using UnityEngine;

namespace Modules.AnimationSystem
{
    [Serializable]
    internal class RagdollJointData
    {
        [field: SerializeField] public Collider Collider { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    }
}
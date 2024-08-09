using System;
using UnityEngine;

namespace Modules.WeaponItemSystem
{
    [Serializable]
    public class ThrowData
    {
        [field: SerializeField] public float Force {get; private set;}
        [field: SerializeField] public float RotationForce {get; private set;}
        [field: SerializeField] public float RotationZ { get; private set; } = 90f;
        [field: SerializeField] public float MeleeRotationY {get; private set;}
        [field: SerializeField] public float RangeRotationY { get; private set; } = 90f;
        [field: SerializeField] public float RotationX {get; private set;}
    }
}
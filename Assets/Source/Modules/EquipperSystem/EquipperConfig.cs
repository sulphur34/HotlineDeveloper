using UnityEngine;

namespace Modules.EquipperSystem
{
    public class EquipperConfig
    {
        [field: SerializeField] public Transform ItemContainer { get; private set; }
        [field: SerializeField] public Transform RightHandPlaceholder { get; private set; }
        [field: SerializeField] public Transform LeftHandPlaceholder { get; private set; }
        [field: SerializeField] public float ThrowSpeed { get; private set; }
    }
}
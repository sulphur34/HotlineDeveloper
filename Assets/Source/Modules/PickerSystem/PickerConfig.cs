using UnityEngine;

namespace Modules.PickerSystem
{
    public class PickerConfig : ScriptableObject
    {
        [field : SerializeField] public float PickRadius { get; private set; }
        [field : SerializeField] public Vector3 Position { get; private set; }
    }
}
using UnityEngine;

namespace Modules.PickerSystem
{
    [CreateAssetMenu(fileName = "Picker Config")]
    public class PickerConfig : ScriptableObject
    {
        [field : SerializeField] public float Radius { get; private set; }
        [field : SerializeField] public Transform Position { get; private set; }
    }
}
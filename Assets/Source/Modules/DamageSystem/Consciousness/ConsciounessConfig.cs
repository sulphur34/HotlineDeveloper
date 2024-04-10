using UnityEngine;

namespace Modules.DamageSystem
{
    public class ConsciounessConfig : ScriptableObject
    {
        [field : SerializeField] public float RecoverTime { get; private set; }
    }
}
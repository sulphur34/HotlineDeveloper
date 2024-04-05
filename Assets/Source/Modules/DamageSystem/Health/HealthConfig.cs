using UnityEngine;

namespace Modules.DamageSystem
{
    public class HealthConfig : ScriptableObject
    {
        [field : SerializeField] public float MaxValue { get; private set; }
    }
}
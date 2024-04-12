using UnityEngine;

namespace Modules.DamageSystem
{
    [CreateAssetMenu(fileName = "Health Config")]
    public class HealthConfig : ScriptableObject
    {
        [field : SerializeField] public float MaxValue { get; private set; }
    }
}
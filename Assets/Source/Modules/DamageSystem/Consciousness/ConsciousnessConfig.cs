using UnityEngine;

namespace Modules.DamageSystem
{
    [CreateAssetMenu(fileName = "Consciouness Config")]
    public class ConsciousnessConfig : ScriptableObject
    {
        [field : SerializeField] public float RecoverTime { get; private set; }
    }
}
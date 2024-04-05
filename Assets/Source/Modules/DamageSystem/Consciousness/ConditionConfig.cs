using UnityEngine;

namespace Modules.DamageSystem
{
    public class ConditionConfig : ScriptableObject
    {
        [field : SerializeField] public float RecoverTime { get; private set; }
    }
}
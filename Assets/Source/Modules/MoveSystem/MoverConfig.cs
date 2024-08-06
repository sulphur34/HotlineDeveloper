using UnityEngine;

namespace Modules.MoveSystem
{
    [CreateAssetMenu(fileName = "Move Config")]
    public class MoverConfig : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
        [field : SerializeField] public float GravityModifier { get; private set; } = -0.08f;
    }
}
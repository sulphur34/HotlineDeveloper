using UnityEngine;

namespace Modules.MoveSystem
{
    [CreateAssetMenu(fileName = "Move Config")]
    public class MoverConfig : ScriptableObject
    {
        [field : SerializeField] public float MoveSpeed { get; private set; }
        [field : SerializeField] public float RotationSpeed { get; private set; }
    }
}
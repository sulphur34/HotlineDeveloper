using UnityEngine;

namespace Modules.Characters.Enemies.EnemyBehavior
{
    public class BehaviourConfig : ScriptableObject
    {
        [field: SerializeField] public Vector3[] PatrolPoints { get; private set; }
        
    }
}
using Modules.Characters.Enemies;
using Modules.Characters.Enemies.EnemyBehavior;
using UnityEngine;

namespace Modules.EnemySpawnSystem
{
    [CreateAssetMenu(fileName = "Enemy Spawn Config")]
    public class EnemySpawnConfig : ScriptableObject
    {
        [field: SerializeField] public Enemy Prefab { get; private set; }
        [field: SerializeField] public Behaviors Behavior { get; private set; }
        [field: SerializeField] public Transform SpawnPoint { get; private set; }
        [field: SerializeField] public PatrolRoute PatrolRoute { get; private set; }
    }
}
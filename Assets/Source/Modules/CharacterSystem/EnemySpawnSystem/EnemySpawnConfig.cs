using Modules.Characters.Enemies;
using Modules.Characters.Enemies.EnemyBehavior;
using Modules.DamageReceiverSystem;
using UnityEngine;

namespace Modules.EnemySpawnSystem
{
    [CreateAssetMenu(fileName = "Enemy Spawn Config")]
    internal class EnemySpawnConfig : ScriptableObject
    {
        [field: SerializeField] internal Enemy Prefab { get; private set; }
        [field: SerializeField] internal Behaviors Behavior { get; private set; }
        
        [field: SerializeField] internal DamageableTypes DamageableType { get; private set; }
        [field: SerializeField] internal Transform SpawnPoint { get; private set; }
        [field: SerializeField] internal PatrolRoute PatrolRoute { get; private set; }
    }
}
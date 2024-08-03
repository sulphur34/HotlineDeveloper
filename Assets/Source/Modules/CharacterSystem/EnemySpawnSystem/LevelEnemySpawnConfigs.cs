using UnityEngine;

namespace Modules.EnemySpawnSystem
{
    [CreateAssetMenu(fileName = "Level Spawn Config")]
    public class LevelEnemySpawnConfigs : ScriptableObject
    {
        [field: SerializeField] internal EnemySpawnConfig[] EnemySpawnConfigs { get; private set; }
    }
}
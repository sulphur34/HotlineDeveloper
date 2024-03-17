using UnityEngine;

namespace Modules.Items.Weapons
{
    [CreateAssetMenu(fileName = "Bullet Config")]
    internal class BulletConfig : ScriptableObject
    {
        [field: SerializeField] internal Bullet Prefab { get; private set; }
        [field: SerializeField] internal float Speed { get; private set; }
    }
}
using Modules.MoveSystem;
using UnityEngine;

namespace Modules.Characters
{
    [CreateAssetMenu(fileName = "Character Config")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public Character CharacterPrefab { get; private set; }
        [field: SerializeField] public MoverConfig MoverConfig { get; private set; }
    }
}
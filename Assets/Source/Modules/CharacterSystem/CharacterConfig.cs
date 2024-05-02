using Modules.DamageSystem;
using UnityEngine;

namespace Modules.Characters
{
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public Character CharacterPrefab { get; private set; }
    }
}
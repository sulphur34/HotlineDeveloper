using Modules.DamageSystem;
using Modules.PickerSystem;
using Source.Modules.EquipperSystem;
using UnityEngine;

namespace Modules.Characters
{
    [CreateAssetMenu(fileName = "Character Config")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public Character CharacterPrefab { get; private set; }
        [field: SerializeField] public HealthConfig HealthConfig { get; private set; }
    }
}
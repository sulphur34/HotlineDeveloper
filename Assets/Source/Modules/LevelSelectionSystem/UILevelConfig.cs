using UnityEngine;

namespace Modules.LevelSelectionSystem
{
    [CreateAssetMenu(fileName = "UI Level Config", menuName = "Data/UI Level Config")]
    public class UILevelConfig : ScriptableObject
    {
        [field: SerializeField] public uint LevelNumber { get; private set; }

        [field: SerializeField] public string LevelName { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
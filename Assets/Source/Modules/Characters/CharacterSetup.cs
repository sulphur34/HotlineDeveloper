using Modules.MoveSystem;
using UnityEngine;
using VContainer;

namespace Modules.Characters
{
    public class CharacterSetup : MonoBehaviour
    {
        [Inject]
        private void Construct(CharacterConfig config)
        {
            Character character = Instantiate(config.CharacterPrefab);
        }
    }
}
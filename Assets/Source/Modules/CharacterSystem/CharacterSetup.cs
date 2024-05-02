using Modules.DamageSystem;
using UnityEngine;
using VContainer;

namespace Modules.Characters
{
    public class CharacterSetup : MonoBehaviour
    {
        [Inject]
        private void Construct(CharacterConfig characterConfig)
        {
        }
    }
}
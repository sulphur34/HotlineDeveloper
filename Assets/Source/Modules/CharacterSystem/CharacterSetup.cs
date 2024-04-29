using Modules.DamageSystem;
using UnityEngine;
using VContainer;

namespace Modules.Characters
{
    [RequireComponent(typeof(HealthSetup))]
    public class CharacterSetup : MonoBehaviour
    {
        
        [Inject]
        private void Construct(CharacterConfig characterConfig)
        {
            Character character = new Character();
        }
    }
}
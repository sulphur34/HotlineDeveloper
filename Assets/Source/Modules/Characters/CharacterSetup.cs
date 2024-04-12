using Modules.DamageSystem;
using Modules.PickerSystem;
using Source.Modules.EquipperSystem;
using UnityEngine;
using VContainer;

namespace Modules.Characters
{
    [RequireComponent(typeof(HealthSetup))]
    [RequireComponent(typeof(EquipperSetup))]
    [RequireComponent(typeof(PickerSetup))]
    public class CharacterSetup : MonoBehaviour
    {
        
        [Inject]
        private void Construct(CharacterConfig characterConfig)
        {
            Character character = new Character();
        }
    }
}
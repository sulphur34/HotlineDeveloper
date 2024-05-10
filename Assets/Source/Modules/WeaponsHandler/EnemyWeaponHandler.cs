using Modules.InputSystem;
using Modules.InputSystem.Interfaces;
using UnityEngine;
using VContainer;

namespace Modules.PlayerWeaponsHandler
{
    public class EnemyWeaponHandler : WeaponHandler
    {
        public void Initialize(AiInput aiInput)
        {
            ShotInput = aiInput;
            WeaponItemInput = aiInput;
            WeaponItemInput.PickReceived += OnWeaponItemInputReceived;
        }
    }
}
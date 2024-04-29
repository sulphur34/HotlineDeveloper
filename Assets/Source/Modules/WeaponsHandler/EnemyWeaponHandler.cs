using Source.Modules.InputSystem;
using Source.Modules.InputSystem.Interfaces;
using UnityEngine;
using VContainer;

namespace Modules.PlayerWeaponsHandler
{
    public class EnemyWeaponHandler : WeaponHandler
    {
        public void Initialize(AiInput aiInput)
        {
            _shotInput = aiInput;
            _weaponItemInput = aiInput;
            _weaponItemInput.PickReceived += OnWeaponItemInputReceived;
        }
    }
}
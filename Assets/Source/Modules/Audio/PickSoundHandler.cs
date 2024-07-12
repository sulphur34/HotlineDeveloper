using Modules.PlayerWeaponsHandler;
using Modules.Weapons.WeaponItemSystem;
using Modules.Weapons.WeaponTypeSystem;
using UnityEngine;

namespace Modules.Audio
{
    [RequireComponent(typeof(WeaponHandlerView))]
    public class PickSoundHandler : SoundHandler
    {
        [SerializeField] private AudioSourceNames _meleeAudioName;
        [SerializeField] private AudioSourceNames _rangeAudioName;

        private WeaponHandlerView _weaponHandler;

        protected override void Awake()
        {
            base.Awake();
            _weaponHandler = GetComponent<WeaponHandlerView>();
            _weaponHandler.Equipped += OnReceive;
        }

        private void OnReceive()
        {
            if (_weaponHandler.WeaponInfo.CurrentWeaponType == WeaponType.Melee)
                Play(_meleeAudioName);
            else
                Play(_rangeAudioName);
        }
    }
}
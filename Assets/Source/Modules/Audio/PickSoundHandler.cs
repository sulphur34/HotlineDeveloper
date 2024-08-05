using Modules.PlayerWeaponsHandler;
using Modules.Weapons.WeaponTypeSystem;
using Plugins.Audio.Utils;
using UnityEngine;

namespace Modules.Audio
{
    [RequireComponent(typeof(WeaponHandlerView))]
    internal class PickSoundHandler : SoundHandler
    {
        [SerializeField] private AudioDataProperty _meleeAudioName;
        [SerializeField] private AudioDataProperty _rangeAudioName;

        private WeaponHandlerView _weaponHandler;

        protected override void Awake()
        {
            base.Awake();
            _weaponHandler = GetComponent<WeaponHandlerView>();
            _weaponHandler.Equipped += OnReceive;
        }
        
        private void OnDestroy()
        {
            _weaponHandler.Equipped -= OnReceive;
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
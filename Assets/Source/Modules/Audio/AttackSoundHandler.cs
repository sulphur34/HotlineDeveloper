using System;
using Modules.Weapons.WeaponItemSystem;
using Modules.Weapons.WeaponTypeSystem;
using Plugins.Audio.Utils;
using UnityEngine;

namespace Modules.Audio
{
    [RequireComponent(typeof(WeaponItem))]
    public class AttackSoundHandler : SoundHandler
    {
        [SerializeField] private AudioDataProperty _audioName;

        private WeaponItem _weaponItem;

        protected override void Awake()
        {
            base.Awake();
            _weaponItem = GetComponent<WeaponItem>();
            _weaponItem.Attacked += OnAttack;
        }

        private void OnDestroy()
        {
            _weaponItem.Attacked -= OnAttack;
        }

        private void OnAttack(WeaponType type)
        {
            Play(_audioName);
        }
    }
}
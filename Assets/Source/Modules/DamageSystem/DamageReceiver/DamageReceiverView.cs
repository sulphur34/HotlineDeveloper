using System;
using Modules.PlayerWeaponsHandler;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.DamageSystem
{
    [RequireComponent(typeof(Collider))]
    public class DamageReceiverView : MonoBehaviour, IDamageReceiver
    {
        private WeaponHandlerView _weaponHandler;
        public event Action<DamageData> Received;
        public event Action FallenDown;
        public event Action StoodUp;
        
        public bool IsDead { get; private set; }
        public bool IsKnocked { get; private set; }

        private void Awake()
        {
            _weaponHandler = GetComponent<WeaponHandlerView>();
        }

        public void Receive(DamageData damageData)
        {
            Received?.Invoke(damageData);
        }
       
        public void OnKnocked()
        {
            IsKnocked = true;
            OnFall();
        }

        public void OnRecovered()
        {
            IsKnocked = false;
        }

        public void OnHealthChanged(float value)
        {
        }

        public void OnDeath()
        {
            IsDead = true;
            OnFall();
        }

        private void OnFall()
        {
            _weaponHandler.UnequipWeapon();
            FallenDown?.Invoke();
        }
    }
}
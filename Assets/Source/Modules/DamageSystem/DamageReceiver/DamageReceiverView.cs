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
        
        public bool IsDead { get; private set; }
        public bool IsKnocked { get; private set; }

        private void Awake()
        {
            _weaponHandler = GetComponent<WeaponHandlerView>();
        }

        private void LateUpdate()
        {
            if(IsDead || IsKnocked)
                TestDeathAnimation();
        }

        public void Receive(DamageData damageData)
        {
            Received?.Invoke(damageData);
        }
       
        public void OnKnocked()
        {
            IsKnocked = true;
            _weaponHandler.UnequipWeapon();
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
            _weaponHandler.UnequipWeapon();
        }

        private void TestDeathAnimation()
        {
            transform.RotateAround(transform.position, Vector3.forward, 90f);
        }
    }
}
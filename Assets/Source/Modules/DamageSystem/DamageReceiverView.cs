using System;
using System.Runtime.CompilerServices;
using Modules.DamageSystem;
using UnityEngine;

namespace Source.Modules.DamageSystem
{
    [RequireComponent(typeof(Collider))]
    public class DamageReceiverView : MonoBehaviour, IDamageReceiver
    {
        public event Action<DamageData> Received;
        
        public bool IsDead { get; private set; }
        public bool IsKnocked { get; private set; }

        public void Receive(DamageData damageData)
        {
            Received?.Invoke(damageData);
        }
       
        public void OnKnocked()
        {
            IsKnocked = true;
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
        }
    }
}
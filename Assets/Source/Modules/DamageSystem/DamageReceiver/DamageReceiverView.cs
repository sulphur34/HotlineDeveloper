using System;
using UnityEngine;
using UnityEngine.AI;

namespace Modules.DamageSystem
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
            TestDeathAnimation();   
        }

        public void OnRecovered()
        {
            IsKnocked = false;
            TestRecoverAnimation();
        }

        public void OnHealthChanged(float value)
        {
        }

        public void OnDeath()
        {
            TestDeathAnimation();
            IsDead = true;
        }

        private void TestDeathAnimation()
        {
            GetComponent<NavMeshAgent>().enabled = false;
            transform.RotateAround(transform.position, Vector3.forward, 90f);
        }
        
        private void TestRecoverAnimation()
        {
            GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
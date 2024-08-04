using System;
using UnityEngine;

namespace Modules.DamageReceiverSystem
{
    [RequireComponent(typeof(IDamageInflictStrategy))]
    public class Damager : MonoBehaviour
    {
        [SerializeField] private DamageData _damageData;
        
        private IDamageInflictStrategy _damageStrategy;
        
        private void Awake()
        {
            _damageStrategy = GetComponent<IDamageInflictStrategy>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DamageReceiverView damageReceiverView))
            {
                _damageStrategy.InflictDamage(damageReceiverView, _damageData);
            }
        }
    }
}
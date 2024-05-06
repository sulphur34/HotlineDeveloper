using UnityEngine;

namespace Modules.DamageSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class Damager : MonoBehaviour
    {
        [SerializeField] private DamageData _damageData;
        [SerializeField] private float _lethalSpeed;
        
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DamageReceiverView damageReceiverView))
            {
                damageReceiverView.Receive(_damageData);
            }
        }
    }
}
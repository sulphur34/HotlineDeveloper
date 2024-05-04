using UnityEngine;

namespace Modules.DamageSystem
{
    public class Damager : MonoBehaviour
    { 
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DamageReceiverView damageReceiverView))
            {
                damageReceiverView.Receive(DamageData.RangeDamage);
            }
        }
    }
}
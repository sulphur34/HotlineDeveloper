using UnityEngine;
using UnityEngine.UI;

namespace Modules.DamageSystem
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider _healthbar;
        
        public void OnUpdate(float health)
        {
            _healthbar.value = health;
        }

        public void OnDeath()
        {
            
        }
    }
}
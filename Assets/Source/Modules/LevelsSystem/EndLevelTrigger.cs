using System;
using UnityEngine;

namespace Modules.LevelsSystem
{
    [RequireComponent(typeof(Collider), typeof(ParticleSystem))]
    public class EndLevelTrigger : MonoBehaviour
    {
        
        private Collider _collider;

        public void Activate()
        {
            _collider.enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections;
using UnityEngine;

namespace Modules.DamageSystem
{
    internal class Consciousness : IKnockable
    {
        private WaitForSeconds _waitForSeconds;
        public bool IsConscious { get; private set; }

        public event Action Recovered;
    
        public Consciousness(float recoverTime)
        {
            _waitForSeconds = new WaitForSeconds(recoverTime);
        }

        public void Knockout()
        {
            IsConscious = false;
        }

        public IEnumerator Recovering()
        {
            yield return _waitForSeconds;
            IsConscious = true;
            Recovered?.Invoke();
        }
    }
}

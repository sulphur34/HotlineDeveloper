using System;
using System.Collections;
using UnityEngine;

namespace Modules.DamageSystem
{
    public class Consciouness : IKnockable
    {
        private WaitForSeconds _waitForSeconds;
        public bool IsConscious { get; private set; }

        public event Action Knoked;
        public event Action Recovered;
    
        public Consciouness(float recoverTime)
        {
            _waitForSeconds = new WaitForSeconds(recoverTime);
        }

        public void Knockout()
        {
            IsConscious = false;
            Knoked?.Invoke();
        }

        public IEnumerator Recovering()
        {
            yield return _waitForSeconds;
            IsConscious = true;
            Recovered?.Invoke();
        }
    }
}

using System.Collections;
using UnityEngine;

namespace Modules.Items.Weapons
{
    internal class WeaponRechargeTime
    {
        private readonly WaitForSeconds _waitForSeconds;

        internal WeaponRechargeTime(float value)
        {
            _waitForSeconds = new WaitForSeconds(value);
        }

        internal bool Recharged { get; private set; } = true;

        internal IEnumerator WaitRecharged()
        {
            yield return _waitForSeconds;
            Recharged = true;
        }

        internal void Discharge()
        {
            Recharged = false;
        }
    }
}
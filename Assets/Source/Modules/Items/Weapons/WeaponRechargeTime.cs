using System.Collections;
using UnityEngine;

namespace Modules.Items.Weapons
{
    internal class WeaponRechargeTime
    {
        internal bool Recharged { get; private set; } = true;

        private readonly WaitForSeconds _waitForSeconds;

        internal WeaponRechargeTime(float value)
        {
            _waitForSeconds = new WaitForSeconds(value);
        }

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
using System.Collections;
using UnityEngine;

namespace Modules.Items.Weapons.Melee
{
    internal class MeleeWeapon : Weapon
    {
        private readonly Collider _collider;
        private readonly float _attakeTime;

        public MeleeWeapon(
            MonoBehaviour coroutineStarter, 
            float rechargeTime, 
            Collider collider, 
            float attakeTime) : base(coroutineStarter, rechargeTime)
        {
            _collider = collider;
            _attakeTime = attakeTime;
        }

        protected override bool CanAttack => true;

        protected override void RealizeAttack()
        {
            StartCoroutine(DisableAttack());
        }

        private IEnumerator DisableAttack()
        {
            yield return new WaitForSeconds(_attakeTime);
            _collider.enabled = false;
        }
    }
}
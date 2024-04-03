using System;
using System.Collections;
using UnityEngine;

namespace Modules.Items.Weapons.Melee
{
    internal class MeleeAttackModule : IMeleeAttackModule
    {
        private readonly Collider _collider;
        private readonly float _attakeTime;
        private readonly MonoBehaviour _monoBehaviour;

        public MeleeAttackModule(Collider collider, float attakeTime, MonoBehaviour monoBehaviour)
        {
            _collider = collider;
            _attakeTime = attakeTime;
            _monoBehaviour = monoBehaviour;
        }

        public event Action Attacked;

        public void Attack()
        {
            _monoBehaviour.StartCoroutine(DisableAttack());
        }

        private IEnumerator DisableAttack()
        {
            yield return new WaitForSeconds(_attakeTime);
            _collider.enabled = false;
        }
    }
}
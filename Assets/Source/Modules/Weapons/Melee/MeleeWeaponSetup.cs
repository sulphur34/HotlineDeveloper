using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.Weapons.Melee
{
    public class MeleeWeaponSetup : WeaponSetup
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private float _attakeTime;

        private void Awake()
        {
            MeleeAttackModule attackModule = new MeleeAttackModule(_collider, _attakeTime, this.GetCancellationTokenOnDestroy());
            Init(_attakeTime, attackModule);
        }
    }
}
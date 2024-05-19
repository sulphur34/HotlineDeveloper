using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.Weapons.Melee
{
    public class MeleeWeaponSetup : WeaponSetup
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private float _attakTime;

        private void Awake()
        {
            MeleeAttackModule attackModule = new MeleeAttackModule(_collider, _attakTime, this.GetCancellationTokenOnDestroy());
            Init(_attakTime, attackModule);
        }
    }
}
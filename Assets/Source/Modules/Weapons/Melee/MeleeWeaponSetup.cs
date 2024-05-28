using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Modules.Weapons.Melee
{
    public class MeleeWeaponSetup : WeaponSetup
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private float _attakTime;

        [Inject]
        private void Construct()
        {
            MeleeAttackModule attackModule = new MeleeAttackModule(_collider, _attakTime, this.GetCancellationTokenOnDestroy());
            Init(_attakTime, attackModule);
        }
    }
}
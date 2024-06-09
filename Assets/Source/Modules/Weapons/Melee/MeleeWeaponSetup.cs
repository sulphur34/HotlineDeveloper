using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Modules.Weapons.Melee
{
    public class MeleeWeaponSetup : WeaponSetup
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private float _attakTime;
        [SerializeField] private float _rechargeTime;
        
        private void Awake()
        {
            MeleeAttackModule attackModule = new MeleeAttackModule(_collider, _attakTime, this.GetCancellationTokenOnDestroy());
            Init(_rechargeTime, attackModule);
        }
    }
}
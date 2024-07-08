using UnityEngine;

namespace Modules.Weapons.Melee
{
    public class MeleeWeaponSetup : WeaponSetup
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private float _attakTime;
        [SerializeField] private float _rechargeTime;

        private MeleeAttackModule _meleeAttackModule;
        
        private void Awake()
        {
            _meleeAttackModule = new MeleeAttackModule(_collider, _attakTime);
            Init(_rechargeTime, _meleeAttackModule, _meleeAttackModule);
        }

        private void OnDestroy()
        {
            _meleeAttackModule.Dispose();
        }
    }
}
using Modules.Items.Weapons.InputSystem;
using UnityEngine;
using VContainer;

namespace Modules.Items.Weapons.Melee
{
    public class MeleeWeaponSetup : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private float _attakeTime;
           
        private WeaponPresenter _weaponPresenter;

        private void OnDestroy()
        {
            _weaponPresenter.Dispose();
        }

        [Inject]
        private void Construct(IShotInput shotInput)
        {
            MeleeAttackModule attackModule = new MeleeAttackModule(_collider, _attakeTime, this);
            WeaponRechargeTime rechargeTime = new WeaponRechargeTime(_attakeTime);
            Weapon weapon = new Weapon(this, rechargeTime, attackModule);
            _weaponPresenter = new WeaponPresenter(weapon, shotInput);
        }
    }
}
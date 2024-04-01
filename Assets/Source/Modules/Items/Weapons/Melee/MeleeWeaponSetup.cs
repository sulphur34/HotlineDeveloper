using Modules.Items.Weapons.InputSystem;
using UnityEngine;
using VContainer;

namespace Modules.Items.Weapons.Melee
{
    public class MeleeWeaponSetup : MonoBehaviour
    {
        [SerializeField] private MeleeWeaponView _meleeWeaponView;
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
            MeleeWeapon meleeWeapon = new MeleeWeapon(this, _attakeTime, _collider, _attakeTime);
            _weaponPresenter = new MeleeWeaponPresenter(meleeWeapon, shotInput, _meleeWeaponView);
        }
    }
}
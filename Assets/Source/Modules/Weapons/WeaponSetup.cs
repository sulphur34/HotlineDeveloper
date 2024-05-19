using Cysharp.Threading.Tasks;
using Modules.Weapons.WeaponItemSystem;
using Modules.Weapons.WeaponTypeSystem;
using UnityEngine;

namespace Modules.Weapons
{
    public abstract class WeaponSetup : MonoBehaviour
    {
        [SerializeField] private WeaponItem _weaponItem;

        private readonly WeaponTypeGetter _weaponTypeGetter = new WeaponTypeGetter();

        protected void Init(float rechargeTime, IAttackModule attackModule)
        {
            WeaponRechargeTime weaponRechargeTime = new WeaponRechargeTime(rechargeTime);
            Weapon weapon = new Weapon(weaponRechargeTime, attackModule, this.GetCancellationTokenOnDestroy());
            _weaponItem.Init(weapon.TryAttack, _weaponTypeGetter.Get(attackModule));
        }
    }
}
using Cysharp.Threading.Tasks;
using Modules.WeaponItemSystem;
using UnityEngine;

namespace Modules.Weapons
{
    public abstract class WeaponSetup : MonoBehaviour
    {
        [SerializeField] private WeaponItem _weaponItem;

        protected virtual void Init(float rechargeTime, IAttackModule attackModule)
        {
            WeaponRechargeTime weaponRechargeTime = new WeaponRechargeTime(rechargeTime);
            Weapon weapon = new Weapon(weaponRechargeTime, attackModule, this.GetCancellationTokenOnDestroy());
            _weaponItem.Init(weapon);
        }
    }
}
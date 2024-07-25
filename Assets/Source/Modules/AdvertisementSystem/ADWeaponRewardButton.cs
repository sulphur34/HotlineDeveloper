using UnityEngine;

namespace Source.Modules.AdvertisementSystem
{
    public class ADWeaponRewardButton : ADRewardedButton
    {
        [SerializeField] private GameObject _weaponGameobject;
        protected override void OnRewardGained()
        {
            _weaponGameobject.SetActive(true);
        }

        protected override void OnButtonClick()
        {
        }

        protected override void OnVideoClose()
        {
        }
    }
}
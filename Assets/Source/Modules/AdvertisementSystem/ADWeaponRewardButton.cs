using UnityEngine;

namespace Source.Modules.AdvertisementSystem
{
    public class ADWeaponRewardButton : ADRewardedButton
    {
        private bool isRewarded = false;

        [SerializeField] private GameObject _weaponGameobject;

        protected override void OnRewardGained()
        {
            isRewarded = true;
        }

        protected override void OnButtonClick()
        {
        }

        protected override void OnVideoClose()
        {
            if (isRewarded)
            {
                _weaponGameobject.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
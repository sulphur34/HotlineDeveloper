using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.AdvertisementSystem
{
    public class ADWeaponRewardButton : ADRewardedButton
    {
        private bool _isRewarded = false;

        [FormerlySerializedAs("_weaponGameobject")] [SerializeField] private GameObject _weaponGameObject;

        protected override void OnRewardGained()
        {
            _isRewarded = true;
        }

        protected override void OnButtonClick()
        {
        }

        protected override void OnVideoClose()
        {
            if (_isRewarded)
            {
                _weaponGameObject.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
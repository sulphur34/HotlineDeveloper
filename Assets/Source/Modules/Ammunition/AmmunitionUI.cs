using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Weapons.Ammunition
{
    public class AmmunitionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _ammunitionText;
        [SerializeField] private Image _ammoIcon;

        public void Initialize(Sprite ammoIcon)
        {
            _ammoIcon.sprite = ammoIcon;
        }

        public void UpdateAmmo(uint count)
        {
            _ammunitionText.text = count.ToString();
        }

        public void Activate(uint count)
        {
            UpdateAmmo(count);
            SetState(true);
        }

        public void Deactivate()
        {
            SetState(false);
        }

        private void SetState(bool isActive)
        {
            _ammunitionText.enabled = isActive;
            _ammoIcon.enabled = isActive;
        }
    }
}
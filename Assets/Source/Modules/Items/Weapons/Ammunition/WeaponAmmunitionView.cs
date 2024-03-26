using TMPro;
using UnityEngine;

namespace Modules.Items.Weapons.Ammunition
{
    public class WeaponAmmunitionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void UpdateCount(uint count)
        {
            _text.text = count.ToString();
        }
    }
}
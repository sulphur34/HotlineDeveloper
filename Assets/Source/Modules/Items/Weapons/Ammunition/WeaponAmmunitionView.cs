using TMPro;
using UnityEngine;

namespace Modules.Items.Weapons.Ammunition
{
    internal class WeaponAmmunitionView : MonoBehaviour, IWeaponAmmunitionView
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void UpdateCount(uint count)
        {
            _text.text = count.ToString();
        }
    }
}
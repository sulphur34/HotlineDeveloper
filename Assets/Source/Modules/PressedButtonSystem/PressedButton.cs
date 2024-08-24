using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.PressedButtonSystem
{
    public class PressedButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public event Action Pressed;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        protected virtual void MakeOnClick()
        {
        }

        private void OnClick()
        {
            MakeOnClick();
            Pressed?.Invoke();
        }
    }
}
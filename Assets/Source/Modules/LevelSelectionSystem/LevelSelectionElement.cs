using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Modules.LevelSelectionSystem
{
    public class LevelSelectionElement : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private UILevelConfig _config;
        [SerializeField] private GameObject _outline;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _levelNumber;
        [SerializeField] private TextMeshProUGUI _levelName;

        public event Action<LevelSelectionElement> Pressed;

        public uint LevelNumberForLoad => _config.LevelNumber;

        private void Start()
        {
            _icon.sprite = _config.Sprite;
            _levelNumber.text = string.Format("{0:00}", _config.LevelNumber);
            _levelName.text = _config.LevelName;
        }

        public void Select()
        {
            _outline.SetActive(true);
        }

        public void Deselect()
        {
            _outline.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed?.Invoke(this);
        }
    }
}
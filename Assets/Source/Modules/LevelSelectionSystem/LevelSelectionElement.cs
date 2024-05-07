using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Modules.LevelSelectionSystem
{
    public class LevelSelectionElement : MonoBehaviour, IPointerDownHandler
    {
        private const string LockedName = "Locked";

        [SerializeField] private UILevelConfig _config;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _levelNumber;
        [SerializeField] private TextMeshProUGUI _levelName;

        [SerializeField] private Sprite _lockedIcon;
        [SerializeField] private GameObject _outline;

        public event Action<LevelSelectionElement> Pressed;
        public event Action<LevelSelectionElement> Selected;

        public bool IsLocked { get; private set; }

        public bool IsSelected { get; private set; }

        public uint LevelNumberForLoad => _config.LevelNumber;

        public void Init(bool isLocked)
        {
            IsLocked = isLocked;
            _levelNumber.text = string.Format("{0:00}", _config.LevelNumber);

            if (isLocked)
            {
                _icon.sprite = _lockedIcon;
                _levelName.text = LockedName;
            }
            else
            {
                _icon.sprite = _config.Sprite;
                _levelName.text = _config.LevelName;
            }
        }

        public void Unlock()
        {
            IsLocked = false;
        }

        public void Select()
        {
            if (IsLocked)
                return;

            _outline.SetActive(true);
            IsSelected = true;
            Selected?.Invoke(this);
        }

        public void Deselect()
        {
            _outline.SetActive(false);
            IsSelected = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (IsLocked == false)
                Pressed?.Invoke(this);
        }
    }
}
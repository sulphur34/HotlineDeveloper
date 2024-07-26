using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Translation = Lean.Localization.LeanLocalization;

namespace Modules.LevelSelectionSystem
{
    public class LevelSelectionElement : MonoBehaviour, IPointerDownHandler
    {
        private const string LockedName = "Locked";
        private const string LevelNamePrefix = "Level";
        private const string LevelNamePostfix = "\\Name";

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

        public int LevelNumberForLoad => (int)_config.LevelNumber;

        private void Start()
        {
           
            Translation.UpdateTranslations();
            
            if (IsLocked)
            {
                _icon.sprite = _lockedIcon;
                _levelName.text = Translation.GetTranslationText(LockedName);
            }
            else
            {
                _icon.sprite = _config.Sprite;
                _levelName.text = Translation.GetTranslationText(TranslationName(_config.LevelNumber));
            }
        }

        public void Init(bool isLocked)
        {
            IsLocked = isLocked;
            _levelNumber.text = string.Format("{0:00}", _config.LevelNumber);
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
            if (IsLocked == false && IsSelected == false)
                Pressed?.Invoke(this);
        }

        private string TranslationName(uint levelNumber)
        {
            return LevelNamePrefix + levelNumber + LevelNamePostfix;
        }
    }
}

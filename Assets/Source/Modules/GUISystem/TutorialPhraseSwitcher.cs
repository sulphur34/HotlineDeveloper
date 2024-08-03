using Lean.Localization;
using UnityEngine;

namespace Modules.ScoreSystem
{
    [RequireComponent(typeof(LeanLocalizedTextMeshProUGUI))]
    public class UILeanPhraseSwitcher : MonoBehaviour
    {
        [SerializeField] private string _desktopTranslationName;
        [SerializeField] private string _mobileTranslationName;

        private LeanLocalizedTextMeshProUGUI _localizedText;

        private void Awake()
        {
            _localizedText = GetComponent<LeanLocalizedTextMeshProUGUI>();

            if (Application.isMobilePlatform)
                _localizedText.TranslationName = _mobileTranslationName;
            else
                _localizedText.TranslationName = _desktopTranslationName;
        }
    }
}
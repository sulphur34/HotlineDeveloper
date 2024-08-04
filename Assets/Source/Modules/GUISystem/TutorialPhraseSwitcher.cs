using Lean.Localization;
using UnityEngine;

namespace Modules.GUISystem
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

            _localizedText.TranslationName =
                Application.isMobilePlatform ? _mobileTranslationName : _desktopTranslationName;
        }
    }
}
using Lean.Localization;
using UnityEngine;

namespace Modules.GUISystem
{
    public class LeanPhraseSwitcher : MonoBehaviour
    {
        [SerializeField] private string _firstTranslationName;
        [SerializeField] private string _secondTranslationName;
        [SerializeField] private LeanLocalizedTextMeshProUGUI _localizedText;

        protected void SetPhrase(bool isFirstOption)
        {
            _localizedText.TranslationName = isFirstOption ? _firstTranslationName : _secondTranslationName;
        }
    }
}
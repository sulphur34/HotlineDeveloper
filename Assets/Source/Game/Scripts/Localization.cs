using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

namespace Modules.FocusSystem
{
    public class Localization : MonoBehaviour
    {
        private const string EnglishCode = "en";
        private const string English = "English";
        private const string RussianCode = "ru";
        private const string Russian = "Russian";
        private const string TurkishCode = "tr";
        private const string Turkish = "Turkish";

        public void Initialize()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
    ChangeLanguage();
#endif
        }

        private void ChangeLanguage()
        {
            string languageCode = YandexGamesSdk.Environment.i18n.lang;

            string language = languageCode switch
            {
                EnglishCode => English,
                RussianCode => Russian,
                TurkishCode => Turkish,
                _ => English
            };

            LeanLocalization.SetCurrentLanguageAll(language);
        }
    }
}
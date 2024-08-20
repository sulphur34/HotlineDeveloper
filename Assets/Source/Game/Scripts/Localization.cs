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
#else
            int i = Random.Range(0, 3);
            switch (i)
            {
                case 0:
                    LeanLocalization.SetCurrentLanguageAll(English);
                    break;
                case 1:
                    LeanLocalization.SetCurrentLanguageAll(Russian);
                    break;
                case 2:
                    LeanLocalization.SetCurrentLanguageAll(Turkish);
                    break;
            }
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
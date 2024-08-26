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
            LeanLocalization.SetCurrentLanguageAll(English);
        }
    }
}
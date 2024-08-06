using Modules.GUISystem;

namespace Modules.NextLevelButtonSystem
{
    public class NextLevelButtonView : LeanPhraseSwitcher
    {
        internal void SetNextLevelText()
        {
            SetPhrase(true);
        }

        internal void SetGameEndText()
        {
            SetPhrase(false);
        }
    }
}
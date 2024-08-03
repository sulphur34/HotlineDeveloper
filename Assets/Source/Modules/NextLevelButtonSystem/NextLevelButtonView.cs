using Modules.ScoreSystem;

namespace Source.Modules.NextLevelButtonSystem
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
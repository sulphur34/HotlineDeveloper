using Modules.FadeSystem;
using Modules.LevelSelectionSystem;
using Modules.LevelsSystem;
using Modules.SceneLoaderSystem;
using VContainer;

namespace Modules.NextLevelButtonSystem
{
    public class NextLevelButtonPresenter
    {
        [Inject]
        internal NextLevelButtonPresenter(
            LevelsData levels,
            NextLevelButton nextLevelButton,
            NextLevelButtonView view,
            LevelSceneLoader levelSceneLoader,
            SceneLoader sceneLoader,
            Fade fade)
        {
            int currentLevelIndex = levels.ForLoad;
            nextLevelButton.Initialize(levels, levelSceneLoader, sceneLoader, fade, currentLevelIndex);

            if (currentLevelIndex >= levels.Value.Count)
                view.SetGameEndText();
            else
                view.SetNextLevelText();
        }
    }
}
using Modules.FadeSystem;
using Modules.LevelSelectionSystem;
using Modules.LevelsSystem;
using Modules.SceneLoaderSystem;
using VContainer;

namespace Modules.NextLevelButtonSystem
{
    public class NextLevelButtonPresenter
    {
        internal int _currentLevelIndex;
        
        [Inject]
        internal NextLevelButtonPresenter(
            LevelsData levels,
            NextLevelButton nextLevelButton, 
            NextLevelButtonView view, 
            LevelSceneLoader levelSceneLoader,
            SceneLoader sceneLoader,
            Fade fade
            )
        {
            _currentLevelIndex = levels.ForLoad;
            nextLevelButton.Initialize(levels, levelSceneLoader, sceneLoader, fade, _currentLevelIndex);
            
            if (_currentLevelIndex >= levels.Value.Count)
                view.SetGameEndText();
            else
                view.SetNextLevelText();
        }
    }
}
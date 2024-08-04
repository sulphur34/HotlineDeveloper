using Modules.FadeSystem;
using Modules.LevelSelectionSystem;
using Modules.LevelsSystem;
using Modules.PressedButtonSystem;
using Modules.SceneLoaderSystem;

namespace Source.Modules.NextLevelButtonSystem
{
    public class NextLevelButton : PressedButton
    {
        private LevelsData _levels;
        private LevelSceneLoader _levelSceneLoader;
        private SceneLoader _sceneLoader;
        private int _currentLevelIndex;
        private Fade _fade;

        internal void Init(LevelsData levels, LevelSceneLoader levelSceneLoader, SceneLoader sceneLoader, Fade fade,
            int currentLevelIndex)
        {
            _levels = levels;
            _fade = fade;
            _currentLevelIndex = currentLevelIndex;
            _levelSceneLoader = levelSceneLoader;
            _sceneLoader = sceneLoader;
        }

        protected override void MakeOnClick()
        {
            if (_currentLevelIndex < _levels.Value.Count)
            {
                _levels.ForLoad = _levels.ForLoad + 1;
                _levelSceneLoader.Load(_currentLevelIndex + 1);
                return;
            }
            
            _fade.In();
            _sceneLoader.Load(SceneName.Menu.ToString(), _fade);
        }
    }
}
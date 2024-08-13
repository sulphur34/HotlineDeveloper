using Modules.AdvertisementSystem;
using Modules.FadeSystem;
using Modules.LevelSelectionSystem;
using Modules.LevelsSystem;
using Modules.PressedButtonSystem;
using Modules.SceneLoaderSystem;
using UnityEngine;

namespace Modules.NextLevelButtonSystem
{
    public class NextLevelButton : PressedButton
    {
        [SerializeField] private bool HasAD = true;
        
        private LevelsData _levels;
        private LevelSceneLoader _levelSceneLoader;
        private SceneLoader _sceneLoader;
        private int _currentLevelIndex;
        private Fade _fade;
        private VideoAD _videoAD;

        internal void Initialize(
            LevelsData levels, 
            LevelSceneLoader levelSceneLoader, 
            SceneLoader sceneLoader, 
            Fade fade,
            int currentLevelIndex)
        {
            _levels = levels;
            _fade = fade;
            _currentLevelIndex = currentLevelIndex;
            _levelSceneLoader = levelSceneLoader;
            _sceneLoader = sceneLoader;
            _videoAD = GetComponent<VideoAD>();
        }

        protected override void MakeOnClick()
        {
#if UNITY_EDITOR
            LoadLevel();
            return;
#endif
            
            if (HasAD)
            {
                _videoAD.Closed += LoadLevel;
                _videoAD.ShowInter();
            }
            else
            {
                LoadLevel();
            }
        }

        private void LoadLevel()
        {
            if (_currentLevelIndex < _levels.Value.Count)
            {
                _levels.ForLoad += 1;
                
                _levelSceneLoader.Load(_currentLevelIndex + 1);
                return;
            }
            
            _fade.In();
            _sceneLoader.Load(SceneName.Menu.ToString(), _fade);
        }
    }
}
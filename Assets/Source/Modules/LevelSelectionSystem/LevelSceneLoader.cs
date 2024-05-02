using Modules.FadeSystem;
using Modules.LevelsSystem;
using Modules.SceneLoaderSystem;
using UnityEngine.SceneManagement;
using VContainer;

namespace Modules.LevelSelectionSystem
{
    public class LevelSceneLoader
    {
        private readonly SceneLoader _sceneLoader;
        private readonly Fade _fade;

        [Inject]
        public LevelSceneLoader(SceneLoader sceneLoader, Fade fade)
        {
            _sceneLoader = sceneLoader;
            _fade = fade;
        }

        internal void Load(Level level)
        {
            string sceneNameForLoad = SceneName.Level.ToString() + level.Number.ToString();

            _fade.In();
            _sceneLoader.Load(sceneNameForLoad, LoadSceneMode.Single, _fade);
        }
    }
}
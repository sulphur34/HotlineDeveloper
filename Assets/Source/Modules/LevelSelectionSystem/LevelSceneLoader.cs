using Modules.FadeSystem;
using Modules.SceneLoaderSystem;
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

        public void Load(int levelNumber)
        {
            string sceneNameForLoad = SceneName.Level.ToString() + levelNumber.ToString();

            _fade.In();
            _sceneLoader.Load(sceneNameForLoad, _fade);
        }
    }
}
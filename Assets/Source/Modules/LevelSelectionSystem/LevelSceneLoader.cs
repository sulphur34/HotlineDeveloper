using Modules.FadeSystem;
using Modules.SceneLoaderSystem;
using VContainer;

namespace Modules.LevelSelectionSystem
{
    public class LevelSceneLoader
    {
        private const string SceneName = "Level";

        private readonly SceneLoader _sceneLoader = new SceneLoader();
        private readonly Fade _fade;

        [Inject]
        public LevelSceneLoader(Fade fade)
        {
            _fade = fade;
        }

        internal void Load(uint levelNumber)
        {
            string sceneNameForLoad = SceneName + levelNumber.ToString();

            _fade.In();
            _sceneLoader.Load(sceneNameForLoad, _fade);
        }
    }
}
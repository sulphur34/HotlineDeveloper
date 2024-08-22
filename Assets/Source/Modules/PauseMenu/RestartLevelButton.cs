using Modules.FadeSystem;
using Modules.PressedButtonSystem;
using Modules.SceneLoaderSystem;
using UnityEngine.SceneManagement;
using VContainer;

namespace Modules.PauseMenu
{
    public class RestartLevelButton : PressedButton
    {
        private SceneLoader _sceneLoader;
        private Fade _fade;

        protected PauseSetter PauseSetter { get; private set; }

        protected override void MakeOnClick()
        {
            PauseSetter.Disable();
            _fade.In();
            _sceneLoader.Load(SceneManager.GetActiveScene().name, _fade);
        }

        [Inject]
        private void Construct(SceneLoader sceneLoader, PauseSetter pauseSetter, Fade fade)
        {
            _sceneLoader = sceneLoader;
            PauseSetter = pauseSetter;
            _fade = fade;
        }
    }
}
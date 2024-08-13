using Modules.FadeSystem;
using Modules.PressedButtonSystem;
using Modules.SceneLoaderSystem;
using UnityEngine.SceneManagement;
using VContainer;

namespace Modules.FocusSystem
{
    public class RestartLevelButton : PressedButton
    {
        private SceneLoader _sceneLoader;
        private Fade _fade;
        private PauseSetter _pauseSetter;

        protected override void MakeOnClick()
        {
            _pauseSetter.Disable();
            _fade.In();
            _sceneLoader.Load(SceneManager.GetActiveScene().name, _fade);
        }

        [Inject]
        private void Construct(SceneLoader sceneLoader, PauseSetter pauseSetter, Fade fade)
        {
            _sceneLoader = sceneLoader;
            _fade = fade;
            _pauseSetter = pauseSetter;
        }
    }
}

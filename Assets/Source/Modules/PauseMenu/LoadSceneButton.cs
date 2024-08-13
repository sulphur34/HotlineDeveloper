using Modules.FadeSystem;
using Modules.PressedButtonSystem;
using Modules.SceneLoaderSystem;
using UnityEngine;
using VContainer;

namespace Modules.FocusSystem
{
    public class LoadSceneButton : PressedButton
    {
        [SerializeField] private SceneName _sceneNameForLoad;

        private SceneLoader _sceneLoader;
        private PauseSetter _pauseSetter;
        private Fade _fade;

        protected override void MakeOnClick()
        {
            _pauseSetter.Disable();
            _fade.In();
            _sceneLoader.Load(_sceneNameForLoad.ToString(), _fade);
        }

        [Inject]
        private void Construct(SceneLoader sceneLoader, PauseSetter pauseSetter, Fade fade)
        {
            _sceneLoader = sceneLoader;
            _pauseSetter = pauseSetter;
            _fade = fade;
        }
    }
}

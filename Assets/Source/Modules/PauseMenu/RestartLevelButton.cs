using Modules.FadeSystem;
using Modules.PauseMenu;
using Modules.PressedButtonSystem;
using Modules.SceneLoaderSystem;
using UnityEngine.SceneManagement;
using VContainer;
using UnityEngine;

public class RestartLevelButton : PressedButton
{
    private SceneLoader _sceneLoader;
    private PauseSetter _pauseSetter;
    private Fade _fade;

    protected override void MakeOnClick()
    {
        _pauseSetter.Disable();
        _fade.In();
        _sceneLoader.Load(SceneManager.GetActiveScene().name, LoadSceneMode.Single, _fade);
    }

    [Inject]
    private void Construct(SceneLoader sceneLoader, PauseSetter pauseSetter, Fade fade)
    {
        _sceneLoader = sceneLoader;
        _pauseSetter = pauseSetter;
        _fade = fade;
    }
}

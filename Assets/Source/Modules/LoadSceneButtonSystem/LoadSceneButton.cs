using Modules.FadeSystem;
using Modules.SceneLoaderSystem;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Fade _fade;
    [SerializeField] private string _sceneName;

    private readonly SceneLoader _sceneLoader = new SceneLoader();

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _fade.In();
        _sceneLoader.Load(_sceneName, _fade);
    }
}

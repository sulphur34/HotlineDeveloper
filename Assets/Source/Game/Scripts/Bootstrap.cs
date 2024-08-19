#if UNITY_EDITOR == false
using Agava.YandexGames;
#endif

using System.Collections;
using Modules.SavingsSystem;
using Modules.SceneLoaderSystem;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private readonly SaveSystem _saveSystem = new SaveSystem();

    private IEnumerator Start()
    {
        yield return StartCoroutine(InitSDK());

        _saveSystem.Load(data =>
        {
            MainCompositRoot mainCompositRoot = FindAnyObjectByType<MainCompositRoot>();
            mainCompositRoot.SetData(data);
            mainCompositRoot.Build();

            SceneLoader sceneLoader = new SceneLoader();
            sceneLoader.Load(SceneName.Menu.ToString());
        });
    }

    private IEnumerator InitSDK()
    {
#if UNITY_EDITOR == false
        yield return YandexGamesSdk.Initialize();
#else
        yield return null;
#endif
    }
}
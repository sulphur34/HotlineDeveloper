#if UNITY_EDITOR == false
using Agava.YandexGames;
#endif

using Modules.SavingsSystem;
using Modules.SceneLoaderSystem;
using System.Collections;
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

            if (data.LevelsData.Value[0].IsCompleted)
            {
                sceneLoader.Load(SceneName.Menu.ToString());
                return;
            }
            
            sceneLoader.Load(SceneName.Level.ToString() + data.LevelsData.Value[0].Number);
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

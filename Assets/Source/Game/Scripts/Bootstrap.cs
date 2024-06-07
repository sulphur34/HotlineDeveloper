using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private IEnumerator Start()
    {
        MainCompositRoot mainCompositRoot = FindAnyObjectByType<MainCompositRoot>();
        yield return StartCoroutine(InitSDK());
        mainCompositRoot.Build();
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

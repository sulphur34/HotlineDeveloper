using UnityEngine;

public class YandexGameReady : MonoBehaviour
{
    private void Awake()
    {
        OnCallGameReadyButtonClick();
    }

    private void OnCallGameReadyButtonClick()
    {
#if (UNITY_EDITOR)
        Debug.Log("Game ready");
#else
YandexGamesSdk.GameReady();
#endif
    }
}
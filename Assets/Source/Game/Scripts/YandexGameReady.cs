using UnityEngine;
using Agava.YandexGames;
using Modules.FocusSystem;

public class YandexGameReady : MonoBehaviour
{
    [SerializeField] private Localization _localization;

    private void Awake()
    {
        OnCallGameReadyButtonClick();
    }

    private void OnCallGameReadyButtonClick()
    {
#if (UNITY_EDITOR)
        Debug.Log("Game ready");
        _localization.Initialize();
#else
        YandexGamesSdk.GameReady();
        _localization.Initialize();
#endif
    }
}
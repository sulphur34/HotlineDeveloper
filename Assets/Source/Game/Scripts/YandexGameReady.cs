using System;
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

    private void Start()
    {
        _localization.Initialize();
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
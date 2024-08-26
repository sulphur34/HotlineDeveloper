using UnityEngine;
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
    }
}
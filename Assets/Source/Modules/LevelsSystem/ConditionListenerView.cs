using Modules.LevelsSystem;
using UnityEngine;
using VContainer;

public class UIConditionListener : MonoBehaviour
{
    [SerializeField] private Canvas _winUI;
    [SerializeField] private Canvas _looseUI;
    
    private LevelConditionManager _levelConditionManager;

    [Inject]
    public void Construct(LevelConditionManager levelConditionManager)
    {
        _levelConditionManager = levelConditionManager;
        _levelConditionManager.Won += OnWin;
        _levelConditionManager.Lost += OnLoose;
    }

    private void OnDestroy()
    {
        _levelConditionManager.Won -= OnWin;
        _levelConditionManager.Lost -= OnLoose;
    }

    private void OnWin()
    {
        _winUI.enabled = true;
    }

    private void OnLoose()
    {
        Time.timeScale = 0;
        _looseUI.enabled = true;
    }
}

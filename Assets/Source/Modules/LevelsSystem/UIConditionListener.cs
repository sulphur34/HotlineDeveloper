using Modules.LevelsSystem;
using UnityEngine;
using VContainer;

namespace Modules.LevelsSystem
{
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
            _looseUI.enabled = true;
        }
    }
}

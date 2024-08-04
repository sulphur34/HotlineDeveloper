using System;
using Modules.LevelsSystem;
using Modules.SavingsSystem;
using Modules.GUISystem;
using UnityEngine;
using VContainer;

namespace Modules.SaveHandlers
{
    public class ScoreSaveHandler : IDisposable
    {
        private readonly SaveSystem _saveSystem = new SaveSystem();
        private readonly LevelConditionManager _levelConditionManager;
        private ScoreCounterView _scoreCounterView;

        [Inject]
        public ScoreSaveHandler(LevelConditionManager levelConditionManager, ScoreCounterView scoreCounterView)
        {
            _scoreCounterView = scoreCounterView;
            _levelConditionManager = levelConditionManager;

            _levelConditionManager.Won += OnLevelCompleted;
        }

        public void Dispose()
        {
            _levelConditionManager.Won -= OnLevelCompleted;
        }

        private void OnLevelCompleted()
        {
            _saveSystem.Save(data =>
            {
                data.LevelsData.Value[_levelConditionManager.LevelCompleteIndex]
                    .UpdateScore((uint)_scoreCounterView.TotalScore);
            });
        }
    }
}
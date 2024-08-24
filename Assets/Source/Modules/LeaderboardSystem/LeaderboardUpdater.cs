using System;
using Modules.LevelsSystem;
using Modules.ScoreSystem;
using VContainer;

namespace Modules.LeaderboardSystem
{
    public class LeaderboardUpdater : IDisposable
    {
        private readonly Leaderboard _leaderboard;
        private readonly ScoreCounter _scoreCounter;
        private readonly LevelConditionManager _levelConditionManager;
        private readonly LevelsData _levelsData;

        [Inject]
        public LeaderboardUpdater(
            Leaderboard leaderboard,
            ScoreCounter scoreCounter,
            LevelConditionManager levelConditionManager,
            LevelsData levelsData)
        {
            _leaderboard = leaderboard;
            _scoreCounter = scoreCounter;
            _levelConditionManager = levelConditionManager;
            _levelsData = levelsData;

            _levelConditionManager.Won += OnWon;
        }

        public void Dispose()
        {
            if (_levelConditionManager != null)
                _levelConditionManager.Won -= OnWon;

            _scoreCounter?.Dispose();
        }

        private void OnWon()
        {
            Level currentLevel = _levelsData.Value[_levelsData.ForLoad - 1];
            currentLevel.UpdateScore(_scoreCounter.TotalScore);
            int levelsTotalScore = 0;

            for (int i = 0; i < _levelsData.Value.Count; i++)
                levelsTotalScore += (int)_levelsData.Value[i].Score;

            _leaderboard.SetPlayer(levelsTotalScore);
        }
    }
}
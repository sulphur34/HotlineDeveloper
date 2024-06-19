using Modules.ScoreCounterSystem;
using VContainer;

namespace Modules.LeaderboardSystem
{
    public class LeaderboardUpdater
    {
        private Leaderboard _leaderboard;
        private ScoreAdder _scoreAdder;

        [Inject]
        public LeaderboardUpdater(Leaderboard leaderboard, ScoreAdder scoreAdder)
        {
            _leaderboard = leaderboard;
            _scoreAdder = scoreAdder;
        }

        public void UpdateLeaderboard()
        {
            // _leaderboard.SetPlayer();
        }

        private void OnGameOver()
        {

        }
    }
}
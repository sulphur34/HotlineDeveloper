using VContainer;

namespace Modules.LeaderboardSystem
{
    public class LeaderboardUpdater
    {
        private Leaderboard _leaderboard;

        [Inject]
        public LeaderboardUpdater(Leaderboard leaderboard)
        {
            _leaderboard = leaderboard;
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
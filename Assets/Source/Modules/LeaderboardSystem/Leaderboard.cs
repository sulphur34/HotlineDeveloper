using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LeaderboardSystem
{
    public class Leaderboard
    {
        public const string AnonymousName = "AnonymousName";

        private const string LeaderboardName = "LeaderboardName";

        private readonly List<LeaderboardPlayerData> _leaderboardPlayers = new List<LeaderboardPlayerData>();

        public event Action<List<LeaderboardPlayerData>> Filled;

        public void SetPlayer(int score)
        {
        }

        public void Fill()
        {
        }

        private void FetchScore(Action<int> onReceivedScore)
        {
        }
    }
}
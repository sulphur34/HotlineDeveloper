using System;
using System.Collections.Generic;
using Agava.YandexGames;
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
            if (Application.isEditor || PlayerAccount.IsAuthorized == false)
                return;

            Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, _ =>
            {
                FetchScore(oldScore =>
                {
                    if (score > oldScore)
                        Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, score);
                });
            });
        }

        public void Fill()
        {
            if (PlayerAccount.IsAuthorized == false)
                return;

            Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, result =>
            {
                _leaderboardPlayers.Clear();

                for (int i = 0; i < result.entries.Length; i++)
                {
                    string name = result.entries[i].player.publicName;
                    int rank = result.entries[i].rank;
                    int coins = result.entries[i].score;

                    if (string.IsNullOrEmpty(name))
                        name = AnonymousName;

                    _leaderboardPlayers.Add(new LeaderboardPlayerData(name, rank, coins));
                }

                Filled?.Invoke(_leaderboardPlayers);
            });
        }

        private void FetchScore(Action<int> onReceivedScore)
        {
            if (Application.isEditor || PlayerAccount.IsAuthorized == false)
                return;

            Agava.YandexGames.Leaderboard.GetPlayerEntry(
                LeaderboardName,
                response => { onReceivedScore?.Invoke(response.score); });
        }
    }
}
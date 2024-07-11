using System.Collections.Generic;
using UnityEngine;

namespace Modules.LeaderboardSystem
{
    public class LeaderboardView : MonoBehaviour
    {
        private readonly List<LeaderboardElement> _spawnedElements = new List<LeaderboardElement>();

        [SerializeField] private Transform _elementsContainer;
        [SerializeField] private GameObject _leaderboardContainer;
        [SerializeField] private GameObject _leaderboard;
        [SerializeField] private GameObject _authorizedPanel;
        [SerializeField] private LeaderboardElement _leaderboardElementPrefab;

        public void CreateLeaderboard(List<LeaderboardPlayerData> leaderboardPlayers)
        {
            ClearLeaderboard();

            foreach (LeaderboardPlayerData leaderboardPlayer in leaderboardPlayers)
            {
                LeaderboardElement leaderboardElement = Instantiate(_leaderboardElementPrefab, _elementsContainer);
                leaderboardElement.Init(leaderboardPlayer.Rank, leaderboardPlayer.Name, leaderboardPlayer.Score);
                _spawnedElements.Add(leaderboardElement);
            }
        }

        public void ClearLeaderboard()
        {
            foreach (LeaderboardElement spawnedElement in _spawnedElements)
                Destroy(spawnedElement.gameObject);

            _spawnedElements.Clear();
        }

        public void ShowLeaderboard()
        {
            _leaderboardContainer.SetActive(true);
            _leaderboard.SetActive(true);
        }

        public void ShowAuthorizedPanel()
        {
            _leaderboardContainer.SetActive(true);
            _authorizedPanel.SetActive(true);
        }

        public void HideAuthorizedPanel()
        {
            _leaderboardContainer.SetActive(false);
            _authorizedPanel.SetActive(false);
        }
    }
}
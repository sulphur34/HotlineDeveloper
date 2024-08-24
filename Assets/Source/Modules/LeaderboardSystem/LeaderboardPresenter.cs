using System;
using System.Collections.Generic;
using Agava.YandexGames;
using VContainer;

namespace Modules.LeaderboardSystem
{
    public class LeaderboardPresenter : IDisposable
    {
        private readonly Leaderboard _leaderboard;
        private readonly LeaderboardView _view;
        private readonly LeaderboardOpenButton _openButton;
        private readonly AuthorizationButton _authorizationButton;

        [Inject]
        public LeaderboardPresenter(
            Leaderboard leaderboard,
            LeaderboardView leaderboardView,
            LeaderboardOpenButton openButton,
            AuthorizationButton authorizationButton)
        {
            _leaderboard = leaderboard;
            _view = leaderboardView;
            _openButton = openButton;
            _authorizationButton = authorizationButton;

            _openButton.AuthorizationRequested += OnAuthorizationRequested;
            _openButton.Authorized += OnAuthorized;
            _authorizationButton.AuthorizationPerformed += OnAuthorizationPerformed;
            _leaderboard.Filled += OnFilled;
        }

        public void Dispose()
        {
            _openButton.AuthorizationRequested -= OnAuthorizationRequested;
            _openButton.Authorized -= OnAuthorized;
            _authorizationButton.AuthorizationPerformed -= OnAuthorizationPerformed;
            _leaderboard.Filled -= OnFilled;
        }

        private void OnAuthorizationRequested()
        {
            _view.ShowAuthorizedPanel();
        }

        private void OnAuthorized()
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            _leaderboard.Fill();
            _view.ShowLeaderboard();
        }

        private void OnAuthorizationPerformed()
        {
            _view.HideAuthorizedPanel();
            _openButton.Open();
        }

        private void OnFilled(List<LeaderboardPlayerData> players)
        {
            _view.CreateLeaderboard(players);
        }
    }
}
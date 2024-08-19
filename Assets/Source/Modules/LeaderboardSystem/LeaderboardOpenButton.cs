using System;
using Agava.YandexGames;
using Modules.PressedButtonSystem;

namespace Modules.LeaderboardSystem
{
    public class LeaderboardOpenButton : PressedButton
    {
        public event Action Authorized;

        public event Action AuthorizationRequested;

        public void Open()
        {
            MakeOnClick();
        }

        protected override void MakeOnClick()
        {
            if (PlayerAccount.IsAuthorized)
            {
                Authorized?.Invoke();
                return;
            }

            AuthorizationRequested?.Invoke();
        }
    }
}
using System;
using Agava.YandexGames;
using Modules.PressedButtonSystem;

namespace Modules.LeaderboardSystem
{
    public class AuthorizationButton : PressedButton
    {
        public event Action AuthorizationPerformed;

        protected override void MakeOnClick()
        {
            PlayerAccount.Authorize(() => AuthorizationPerformed?.Invoke());
        }
    }
}
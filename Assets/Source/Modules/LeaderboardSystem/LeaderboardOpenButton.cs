using Modules.PressedButtonSystem;
using System;

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
        }
    }
}
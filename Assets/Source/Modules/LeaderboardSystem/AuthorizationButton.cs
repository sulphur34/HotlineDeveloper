﻿using Modules.PressedButtonSystem;
using System;

namespace Modules.LeaderboardSystem
{
    public class AuthorizationButton : PressedButton
    {
        public event Action AuthorizationPerformed;

        protected override void MakeOnClick()
        {
        }
    }
}
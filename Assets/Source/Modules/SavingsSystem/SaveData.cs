﻿using System;
using Modules.Audio;
using Modules.LevelsSystem;
using UnityEngine.Scripting;

namespace Modules.SavingsSystem
{
    [Serializable]
    public class SaveData
    {
        [field: Preserve] public LevelsData LevelsData = new LevelsData();
        [field: Preserve] public AudioSettingsData AudioSettingsData = new AudioSettingsData();
    }
}
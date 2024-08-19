using System;
using Modules.Audio;
using Modules.LevelsSystem;
using UnityEngine.Scripting;

namespace Modules.SavingsSystem
{
    [Serializable]
    public class SaveData
    {
        [field: Preserve] public LevelsData LevelsData { get; private set; } = new LevelsData();
        [field: Preserve] public AudioSettingsData AudioSettingsData { get; private set; } = new AudioSettingsData();

        public void SetLevelData(LevelsData levelsData)
        {
            if (levelsData == null)
                throw new NullReferenceException("levelsData is null. Please check save system.");

            LevelsData = levelsData;
        }
    }
}
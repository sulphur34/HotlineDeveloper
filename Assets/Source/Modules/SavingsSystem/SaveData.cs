using Modules.LevelsSystem;
using System;
using UnityEngine.Scripting;

namespace Modules.SavingsSystem
{
    [Serializable]
    public class SaveData
    {
        [field: Preserve]
        public LevelsData LevelsData = new LevelsData();
    }
}
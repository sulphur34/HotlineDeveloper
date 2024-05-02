using Modules.LevelsSystem;
using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Modules.SavingsSystem
{
    [Serializable]
    public class SaveData
    {
        [field: Preserve]
        public uint CurrentLevel = 1;
        [field: Preserve]
        public List<Level> Levels;
    }
}
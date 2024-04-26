using System;
using UnityEngine.Scripting;

namespace Modules.SavingsSystem
{
    [Serializable]
    public class SaveData
    {
        [field: Preserve]
        public uint CurrentLevel = 1;
    }
}
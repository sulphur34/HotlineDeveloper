using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Modules.LevelsSystem
{
    [Serializable]
    public class LevelsData
    {
        [field: Preserve] public int ForLoad = 1;
        [field: Preserve] public List<Level> Value = new List<Level>();
    }
}
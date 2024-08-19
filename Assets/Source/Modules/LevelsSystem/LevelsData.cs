using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
using UnityEngine.WSA;

namespace Modules.LevelsSystem
{
    [Serializable]
    public class LevelsData
    {
        [field: Preserve] public int ForLoad { get; private set; } = 1;
        [field: Preserve] public List<Level> Value { get; private set; } = new List<Level>();

        public void AdvanceLevel()
        {
            ForLoad++;
        }

        public void SetForLoad(int level)
        {
            if (level < 0)
                throw new IndexOutOfRangeException("Level index value is out of range. Must be non-negative.");

            if (level >= Value.Count)
                throw new IndexOutOfRangeException(
                    "Level index value is out of range. Must be smaller than the number of levels.");

            ForLoad = level;
        }
    }
}
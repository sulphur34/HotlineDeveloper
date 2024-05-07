using System;
using UnityEngine;

namespace Modules.LevelsSystem
{
    [Serializable]
    public class Level
    {
        private const uint MinNumber = 1;

        public event Action Completed;

        [field: SerializeField] public uint Number { get; private set; } = 1;

        [field: SerializeField] public bool IsLocked { get; private set; } = true;

        public void SetNumber(uint number)
        {
            if (number < MinNumber)
                throw new ArgumentException();

            Number = number;
        }

        public void Unlock()
        {
            IsLocked = false;
        }

        public void Complete()
        {
            Completed?.Invoke();
        }
    }
}

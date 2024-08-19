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

        [field: SerializeField] public bool IsCompleted { get; private set; }

        [field: SerializeField] public uint Score { get; private set; }

        public void SetNumber(uint number)
        {
            if (number < MinNumber)
                throw new ArgumentOutOfRangeException();

            Number = number;
        }

        public void Unlock()
        {
            IsLocked = false;
        }

        public void Complete()
        {
            IsCompleted = true;
            Completed?.Invoke();
        }

        public void UpdateScore(uint score)
        {
            if (score > Score)
                Score = score;
        }
    }
}
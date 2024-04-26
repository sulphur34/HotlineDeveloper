using Modules.SavingsSystem;
using System;
using UnityEngine;

namespace Modules.LevelsSystem
{
    public class LevelHandler : MonoBehaviour
    {
        private readonly SaveSystem _saveSystem = new SaveSystem();

        private Level _level;

        private void OnDestroy()
        {
            _level.Completed -= OnCompleted;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
                _level.Complete();
        }

        public void Init(Level level)
        {
            _level = level;
            _level.Completed += OnCompleted;
        }

        private void OnCompleted()
        {
            _saveSystem.Save(savedData =>
            {
                if (_level.Number == savedData.CurrentLevel)
                    savedData.CurrentLevel++;
            });
        }
    }

    public class Level
    {
        public Level(uint number)
        {
            Number = number;
        }

        public event Action Completed;

        public uint Number { get; private set; } = 1;

        public void Complete()
        {
            Completed?.Invoke();
        }
    }
}

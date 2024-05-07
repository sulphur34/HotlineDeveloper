using Modules.LevelsSystem;
using Modules.SavingsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using VContainer;

namespace Modules.SaveHandlers
{
    public class LevelSaveHandler : IDisposable
    {
        private readonly SaveSystem _saveSystem = new SaveSystem();
        private readonly Level _currentLevel;
        private readonly List<Level> _levels;

        [Inject]
        public LevelSaveHandler(Level currentLevel, List<Level> levels)
        {
            _currentLevel = currentLevel;
            _levels = levels;

            _currentLevel.Completed += OnCompleted;
        }

        public void Dispose()
        {
            _currentLevel.Completed += OnCompleted;
        }

        private void OnCompleted()
        {
            _saveSystem.Save(data =>
            {
                uint nextLevelNumber = data.CurrentLevel + 1;

                if (data.CurrentLevel >= data.Levels.Count)
                    return;

                Level nextLevel = _levels.FirstOrDefault(level => level.Number == nextLevelNumber);
                nextLevel.Unlock();
                data.Levels = _levels;
            });
        }
    }
}
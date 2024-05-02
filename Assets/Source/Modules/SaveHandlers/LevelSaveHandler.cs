using Modules.LevelsSystem;
using Modules.SavingsSystem;
using System;
using System.Linq;

namespace Modules.SaveHandlers
{
    public class LevelSaveHandler : IDisposable
    {
        private readonly SaveSystem _saveSystem = new SaveSystem();
        private readonly Level _currentLevel;

        public LevelSaveHandler(Level currentLevel)
        {
            _currentLevel = currentLevel;

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
                Level currentLevel = data.Levels.FirstOrDefault(level => level.Number == _currentLevel.Number);
                currentLevel.Complete();
            });
        }
    }
}
using Modules.LevelsSystem;
using Modules.SavingsSystem;
using System;
using System.Linq;
using VContainer;

namespace Modules.SaveHandlers
{
    public class LevelSaveHandler : IDisposable
    {
        private readonly SaveSystem _saveSystem = new SaveSystem();
        private readonly LevelsData _levels;

        [Inject]
        public LevelSaveHandler(LevelsData levels)
        {
            _levels = levels;

            foreach (Level level in _levels.Value)
                level.Completed += OnCompleted;
        }

        public void Dispose()
        {
            foreach (Level level in _levels.Value)
                level.Completed -= OnCompleted;
        }

        private void OnCompleted()
        {
            _saveSystem.Save(data =>
            {
                int nextLevelNumber = _levels.ForLoad + 1;
                Level nextLevel = _levels.Value.FirstOrDefault(level => level.Number == nextLevelNumber);

                if (nextLevel == null || nextLevel.IsCompleted)
                    return;

                if (_levels.ForLoad - 1 >= _levels.Value.Count)
                    return;

                nextLevel.Unlock();
                data.LevelsData = _levels;
            });
        }
    }
}
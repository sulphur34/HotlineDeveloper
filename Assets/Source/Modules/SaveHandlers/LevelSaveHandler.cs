using System;
using Modules.LevelsSystem;
using Modules.SavingsSystem;
using VContainer;

namespace Modules.SaveHandlers
{
    public class LevelSaveHandler : IDisposable
    {
        private readonly SaveSystem _saveSystem;
        private readonly LevelsData _levels;

        [Inject]
        public LevelSaveHandler(LevelsData levels)
        {
            _saveSystem = new SaveSystem();
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
                Level nextLevel = _levels.Value.Find(level => level.Number == nextLevelNumber);

                if (nextLevel == null || nextLevel.IsCompleted)
                    return;

                if (_levels.ForLoad - 1 >= _levels.Value.Count)
                    return;

                nextLevel.Unlock();
                data.SetLevelData(_levels);
            });
        }
    }
}
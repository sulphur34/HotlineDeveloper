using Modules.LevelSelectionSystem;
using Modules.SavingsSystem;
using System;
using VContainer;

namespace Modules.SaveHandlers
{
    public class SelectedLevelSaveHandler : IDisposable
    {
        private readonly SaveSystem _saveSystem = new SaveSystem();
        private readonly LevelSelectionElement[] _levelSelectionElements;

        [Inject]
        public SelectedLevelSaveHandler(LevelSelectionElement[] levelSelectionElements)
        {
            _levelSelectionElements = levelSelectionElements;

            foreach (var element in _levelSelectionElements)
                element.Selected += OnSelected;
        }

        public void Dispose()
        {
            foreach (var element in _levelSelectionElements)
                element.Selected -= OnSelected;
        }

        private void OnSelected(LevelSelectionElement element)
        {
            _saveSystem.Save(data =>
            {
                data.LevelsData.Selected = element.LevelNumberForLoad;
            });
        }
    }
}
﻿using System;
using Modules.LevelSelectionSystem;
using Modules.SavingsSystem;
using VContainer;

namespace Modules.SaveHandlers
{
    public class SelectedLevelSaveHandler : IDisposable
    {
        private readonly SaveSystem _saveSystem;
        private readonly LevelSelectionElement[] _levelSelectionElements;

        [Inject]
        public SelectedLevelSaveHandler(LevelSelectionElement[] levelSelectionElements)
        {
            _saveSystem = new SaveSystem();
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
            _saveSystem.Save(data => { data.LevelsData.ForLoad = element.LevelNumberForLoad; });
        }
    }
}
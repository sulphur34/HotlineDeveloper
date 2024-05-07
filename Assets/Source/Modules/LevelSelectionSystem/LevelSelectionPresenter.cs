using Modules.LevelsSystem;
using Modules.PressedButtonSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using VContainer;

namespace Modules.LevelSelectionSystem
{
    public class LevelSelectionPresenter : IDisposable
    {
        private readonly LevelSelectionElement[] _levelSelectionElements;
        private readonly PressedButton _levelSelectionButton;
        private readonly LevelSceneLoader _levelSceneLoader;
        private readonly Level _lastLevelForLoad;

        private LevelSelectionElement _lastSelectedElement;

        [Inject]
        public LevelSelectionPresenter(LevelSelectionElement[] levelSelectionElements, 
            PressedButton levelSelectionButton, 
            LevelSceneLoader levelSceneLoader, 
            Level lastLevelForLoad,
            List<Level> levels)
        {
            _levelSelectionElements = levelSelectionElements;
            _levelSelectionButton = levelSelectionButton;
            _levelSceneLoader = levelSceneLoader;
            _lastLevelForLoad = lastLevelForLoad;

            for (int i = 0; i < _levelSelectionElements.Length; i++)
                _levelSelectionElements[i].Init(levels[i].IsLocked);

            _lastSelectedElement = _levelSelectionElements.FirstOrDefault(element => element.IsSelected);

            _levelSelectionButton.Pressed += OnButtonPressed;

            foreach (LevelSelectionElement element in _levelSelectionElements)
                element.Pressed += OnElementPressed;
        }

        public void Dispose()
        {
            _levelSelectionButton.Pressed -= OnButtonPressed;

            foreach (LevelSelectionElement element in _levelSelectionElements)
                element.Pressed -= OnElementPressed;
        }

        private void OnButtonPressed()
        {
            if (_lastSelectedElement == null) 
                return;

            _lastLevelForLoad.SetNumber(_lastSelectedElement.LevelNumberForLoad);
            _levelSceneLoader.Load(_lastLevelForLoad);
        }

        private void OnElementPressed(LevelSelectionElement levelSelectionElement)
        {
            if (_lastSelectedElement != null)
                _lastSelectedElement.Deselect();

            levelSelectionElement.Select();
            _lastSelectedElement = levelSelectionElement;
        }
    }
}
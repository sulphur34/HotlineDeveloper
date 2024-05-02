using Modules.LevelsSystem;
using Modules.PressedButtonSystem;
using System;
using System.Linq;
using VContainer;

namespace Modules.LevelSelectionSystem
{
    public class LevelSelectionPresenter : IDisposable
    {
        private readonly LevelSelectionElement[] _levelSelectionElements;
        private readonly PressedButton _levelSelectionButton;
        private readonly LevelSceneLoader _levelSceneLoader;
        private readonly Level _loadedLevel;

        private LevelSelectionElement _lastSelectedElement;

        [Inject]
        public LevelSelectionPresenter(LevelSelectionElement[] levelSelectionElements, PressedButton levelSelectionButton, LevelSceneLoader levelSceneLoader, Level loadedLevel)
        {
            _levelSelectionElements = levelSelectionElements;
            _levelSelectionButton = levelSelectionButton;
            _levelSceneLoader = levelSceneLoader;
            _loadedLevel = loadedLevel;
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

            _loadedLevel.SetNumber(_lastSelectedElement.LevelNumberForLoad);
            _levelSceneLoader.Load(_loadedLevel);
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
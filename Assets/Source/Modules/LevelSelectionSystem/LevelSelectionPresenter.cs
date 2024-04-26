using Modules.PressedButtonSystem;
using System;

namespace Modules.LevelSelectionSystem
{
    public class LevelSelectionPresenter : IDisposable
    {
        private readonly LevelSelectionElement[] _levelSelectionElements;
        private readonly PressedButton _levelSelectionButton;
        private readonly LevelSceneLoader _levelSceneLoader;

        private LevelSelectionElement _lastSelectedElement;

        public LevelSelectionPresenter(LevelSelectionElement[] levelSelectionElements, PressedButton levelSelectionButton, LevelSceneLoader levelSceneLoader)
        {
            _levelSelectionElements = levelSelectionElements;
            _levelSelectionButton = levelSelectionButton;
            _levelSceneLoader = levelSceneLoader;

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

            _levelSceneLoader.Load(_lastSelectedElement.LevelNumberForLoad);
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
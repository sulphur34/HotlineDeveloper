using System;
using System.Linq;
using Modules.LevelsSystem;
using Modules.PressedButtonSystem;
using VContainer;

namespace Modules.LevelSelectionSystem
{
    public class LevelSelectionPresenter : IDisposable
    {
        private readonly LevelSelectionElement[] _levelSelectionElements;
        private readonly PressedButton _levelSelectionButton;
        private readonly LevelSceneLoader _levelSceneLoader;
        private readonly LevelsData _levels;

        private LevelSelectionElement _lastSelectedElement;

        [Inject]
        public LevelSelectionPresenter(
            LevelSelectionElement[] levelSelectionElements,
            PressedButton levelSelectionButton,
            LevelSceneLoader levelSceneLoader,
            LevelsData levels)
        {
            _levelSelectionElements = levelSelectionElements;
            _levelSelectionButton = levelSelectionButton;
            _levelSceneLoader = levelSceneLoader;
            _levels = levels;

            for (int i = 0; i < _levelSelectionElements.Length; i++)
                _levelSelectionElements[i].Init(levels.Value[i].IsLocked);

            _lastSelectedElement = _levelSelectionElements.FirstOrDefault(element => element.IsSelected);

            if (_levels.ForLoad == 0)
                _levels.SetForLoad(_lastSelectedElement.LevelNumberForLoad);

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

            _levels.SetForLoad(_lastSelectedElement.LevelNumberForLoad);
            _levelSceneLoader.Load(_levels.ForLoad);
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
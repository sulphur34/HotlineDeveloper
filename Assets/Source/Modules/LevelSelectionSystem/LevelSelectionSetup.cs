using UnityEngine;
using VContainer;

namespace LevelSelectionSystem
{
    public class LevelSelectionSetup : MonoBehaviour
    {
        private LevelSelectionPresenter _levelSelectionPresenter;

        private void OnDestroy()
        {
            _levelSelectionPresenter.Dispose();
        }

        [Inject]
        private void Constructe(LevelSelectionElement[] levelSelectionElements, PressedButton levelSelectionButton, LevelSceneLoader levelSceneLoader)
        {
            _levelSelectionPresenter = new LevelSelectionPresenter(levelSelectionElements, levelSelectionButton, levelSceneLoader);
        }
    }
}
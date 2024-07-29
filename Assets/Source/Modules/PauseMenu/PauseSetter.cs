using Plugins.Audio.Core;
using UnityEditor;
using UnityEngine;
using VContainer;
using PauseState = Source.Modules.FocusSystem.PauseState;

namespace Modules.PauseMenu
{
    public class PauseSetter
    {
        private readonly PauseState _pauseActiveState;
        private readonly PauseState _pauseInactiveState;
        private readonly InputController _inputController;
        private uint _unpauseQueueValue = 1;
        private uint _pauseQueueCounter;

        [Inject]
        public PauseSetter(InputController inputController)
        {
            _inputController = inputController;
            _pauseActiveState = new PauseState(0f, false, true);
            _pauseInactiveState = new PauseState(1f, true, false);
        }

        public void Enable()
        {
            SetPauseState(_pauseActiveState);
            _pauseQueueCounter++;
            Debug.Log("Pause queue" + _pauseQueueCounter);
        }

        public void Disable()
        {
            if (_pauseQueueCounter <= _unpauseQueueValue)
                SetPauseState(_pauseInactiveState);

            _pauseQueueCounter--;
            Debug.Log("Pause queue" + _pauseQueueCounter);
        }

        private void SetPauseState(PauseState pauseState)
        {
            Time.timeScale = pauseState.Timescale;
            _inputController.enabled = pauseState.IsInputEnabled;

            if (pauseState.isAudioPaused)
                AudioPauseHandler.Instance?.PauseAudio();
            else
                AudioPauseHandler.Instance?.UnpauseAudio();
        }
    }
}
using Modules.InputSystem.PlayerInput;
using Plugins.Audio.Core;
using UnityEngine;
using VContainer;
using PauseState = Modules.FocusSystem.PauseState;

namespace Modules.PauseMenu
{
    public class PauseSetter
    {
        private readonly uint _unpauseQueueValue = 1;
        private readonly PauseState _pauseActiveState;
        private readonly PauseState _pauseInactiveState;
        private readonly InputController _inputController;

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
        }

        public void Disable()
        {
            if (_pauseQueueCounter <= _unpauseQueueValue)
                SetPauseState(_pauseInactiveState);

            if (_pauseQueueCounter > 0)
                _pauseQueueCounter--;
        }

        private void SetPauseState(PauseState pauseState)
        {
            Time.timeScale = pauseState.Timescale;

            if (_inputController != null)
                _inputController.enabled = pauseState.IsInputEnabled;

            if (pauseState.IsAudioPaused)
                AudioPauseHandler.Instance?.PauseAudio();
            else
                AudioPauseHandler.Instance?.UnpauseAudio();
        }
    }
}
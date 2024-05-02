using Modules.PressedButtonSystem;
using UnityEngine;
using VContainer;

namespace Modules.PauseMenu
{
    public class PauseSetButton : PressedButton
    {
        [SerializeField] private PauseMode _pauseMode;

        private PauseSetter _pauseSetter;

        protected override void MakeOnClick()
        {
            switch (_pauseMode)
            {
                case PauseMode.Enabled:
                    Enable();
                    break;
                case PauseMode.Disabled:
                    Disable();
                    break;
            }
        }

        private void Enable()
        {
            _pauseSetter.Enable();
        }

        private void Disable()
        {
            _pauseSetter.Disable();
        }

        [Inject]
        private void Construct(PauseSetter pauseSetter)
        {
            _pauseSetter = pauseSetter;
        }
    }
}
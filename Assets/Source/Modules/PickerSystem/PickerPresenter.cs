using Modules.InputSystem.Interfaces;

namespace Modules.PickerSystem
{
    public class PickerPresenter
    {
        private IPicker _picker;
        private IPickInput _pickInput;

        public PickerPresenter(IPicker picker, IPickInput pickInput)
        {
            _picker = picker;
            _pickInput = pickInput;
            _pickInput.PickReceived += OnPick;
        }
        
        public void Dispose()
        {
            _pickInput.PickReceived -= OnPick;
        }

        private void OnPick()
        {
            _picker.Pick();
        }
    }
}
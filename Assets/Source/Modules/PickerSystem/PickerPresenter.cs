using Source.Modules.InputSystem.Interfaces;

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
            _pickInput.PickRecieved += OnPick;
        }
        
        public void Dispose()
        {
            _pickInput.PickRecieved -= OnPick;
        }

        private void OnPick()
        {
            _picker.Pick();
        }
    }
}
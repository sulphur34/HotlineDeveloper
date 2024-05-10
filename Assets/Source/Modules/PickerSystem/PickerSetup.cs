using Modules.InputSystem.Interfaces;
using UnityEngine;
using VContainer;

namespace Modules.PickerSystem
{
    public class PickerSetup : MonoBehaviour
    {
        [SerializeField] private Transform _itemPlaceholder;
        private IPickInput _pickInput;
        private PickerPresenter _pickerPresenter;
        private Transform _transform;

        [Inject]
        public void Construct(PickerConfig config, IPickInput pickInput)
        {
            _transform = transform;
            Picker picker = new Picker(config);
        }

        public void OnDestroy()
        {
            _pickerPresenter.Dispose();
        }
    }
}
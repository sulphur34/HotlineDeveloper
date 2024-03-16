using System;
using UnityEngine;
using VContainer;

namespace Modules.Items.ItemPickSystem
{
    public class Item : MonoBehaviour, IPickable
    {
        private IItemSelectionInput _input;
        private bool _canPicked;

        public event Action Picked;

        private void OnDestroy()
        {
            _input.Received -= OnReceived;
        }

        [Inject]
        private void Construct(IItemSelectionInput input)
        {
            _input = input;
            _input.Received += OnReceived;
        }

        private void OnReceived()
        {
            if (_canPicked)
                Picked?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player _))
                _canPicked = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player _))
                _canPicked = false;
        }
    }
}

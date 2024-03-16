using System;
using UnityEngine;

namespace Modules.Items.ItemPickSystem
{
    public class ItemSelectionDesktopInput : MonoBehaviour, IItemSelectionInput
    {
        public event Action Received;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Received?.Invoke();
        }
    }
}

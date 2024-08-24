using Modules.SavingsSystem;
using UnityEngine;

namespace Game.Scripts.Utils
{
    public class DeleteSaveButton : MonoBehaviour
    {
        private SaveSystem _saveSystem = new SaveSystem();

        public void Delete()
        {
            _saveSystem.Clear();
        }
    }
}
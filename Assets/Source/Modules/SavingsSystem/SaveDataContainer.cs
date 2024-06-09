using UnityEngine;

namespace Modules.SavingsSystem
{
    public class SaveDataContainer : MonoBehaviour
    {
        public SaveData SaveData { get; private set; }

        public void Init(SaveData saveData)
        {
            SaveData = saveData;
        }
    }
}
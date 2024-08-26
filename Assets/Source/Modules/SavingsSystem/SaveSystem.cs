using System;
using UnityEngine;

namespace Modules.SavingsSystem
{
    public class SaveSystem
    {
        private const string SaveDataPrefsKey = "SaveDataPrefsKey";

        public void Save(Action<SaveData> dataChanges)
        {
            SaveToPrefs(dataChanges);
        }

        public void Load(Action<SaveData> callback)
        {
            callback?.Invoke(LoadFromPrefs());
        }

        public void Clear()
        {
            string saveDataJson = JsonUtility.ToJson(new SaveData(), true);
            PlayerPrefs.SetString(SaveDataPrefsKey, saveDataJson);
        }

        private void SaveToPrefs(Action<SaveData> dataChanges)
        {
            SaveData saveData = LoadFromPrefs();
            dataChanges?.Invoke(saveData);
            string saveDataJson = JsonUtility.ToJson(saveData, true);
            PlayerPrefs.SetString(SaveDataPrefsKey, saveDataJson);
            PlayerPrefs.Save();
        }

        private SaveData LoadFromPrefs()
        {
            if (PlayerPrefs.HasKey(SaveDataPrefsKey))
            {
                string saveDataJson = PlayerPrefs.GetString(SaveDataPrefsKey);
                return JsonUtility.FromJson<SaveData>(saveDataJson);
            }

            return new SaveData();
        }
    }
}
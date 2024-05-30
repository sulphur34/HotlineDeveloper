using System;
using Agava.YandexGames;
using UnityEngine;

namespace Modules.SavingsSystem
{
    public class SaveSystem
    {
        private const string SaveDataPrefsKey = "SaveDataPrefsKey";

        public void Save(Action<SaveData> dataChanges)
        {
            if (Application.isEditor || PlayerAccount.IsAuthorized == false)
            {
                SaveToPrefs(dataChanges);
                return;
            }

            PlayerAccount.GetCloudSaveData(data =>
            {
                SaveData saveData = JsonUtility.FromJson<SaveData>(data);
                dataChanges?.Invoke(saveData);
                PlayerAccount.SetCloudSaveData(JsonUtility.ToJson(saveData));
            });
        }

        public void Load(Action<SaveData> callback)
        {
            if (Application.isEditor || PlayerAccount.IsAuthorized == false)
            {
                callback?.Invoke(LoadFromPrefs());
                return;
            }

            PlayerAccount.GetCloudSaveData(data =>
            {
                SaveData saveData = JsonUtility.FromJson<SaveData>(data);
                callback?.Invoke(saveData);
            });
        }

        private void SaveToPrefs(Action<SaveData> dataChanges)
        {
            SaveData saveData = LoadFromPrefs();
            dataChanges?.Invoke(saveData);
            string saveDataJson = JsonUtility.ToJson(saveData, true);
            UnityEngine.Debug.Log(saveDataJson);
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
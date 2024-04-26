using System;
using Agava.YandexGames;
using UnityEngine;

namespace Modules.SavingsSystem
{
    public class SaveSystem
    {
        private const string SaveDataPrefsKey = "SaveDataPrefsKey";

        public void Save(Action<SaveData> callback)
        {
            if (Application.isEditor || PlayerAccount.IsAuthorized == false)
            {
                SaveToPrefs(callback);
                return;
            }

            PlayerAccount.GetCloudSaveData(data =>
            {
                SaveData saveData = JsonUtility.FromJson<SaveData>(data);
                callback?.Invoke(saveData);
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

        private void SaveToPrefs(Action<SaveData> callback)
        {
            SaveData saveData = LoadFromPrefs();
            callback?.Invoke(saveData);
            string saveDataJson = JsonUtility.ToJson(saveData);
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
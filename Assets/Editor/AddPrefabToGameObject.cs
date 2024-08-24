using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editor
{
    public class AddPrefabToGameObject : EditorWindow
    {
        private GameObject selectedPrefab;
        private string gameObjectName = "TargetGameObject";

        [MenuItem("Tools/Add Prefab to GameObject in All Scenes")]
        public static void ShowWindow()
        {
            GetWindow<AddPrefabToGameObject>("Add Prefab to GameObject");
        }

        private void OnGUI()
        {
            GUILayout.Label("Add Prefab to GameObject", EditorStyles.boldLabel);

            selectedPrefab = (GameObject)EditorGUILayout.ObjectField("Select Prefab", selectedPrefab, typeof(GameObject), false);
            gameObjectName = EditorGUILayout.TextField("GameObject Name", gameObjectName);

            if (GUILayout.Button("Add Prefab to All Scenes"))
            {
                AddPrefabToAllScenes(selectedPrefab, gameObjectName);
            }
        }

        private void AddPrefabToAllScenes(GameObject prefab, string gameObjectName)
        {
            if (prefab == null)
            {
                Debug.LogError("No prefab selected.");
                return;
            }

            string[] sceneGuids = AssetDatabase.FindAssets("t:Scene");
            List<string> scenePaths = new List<string>();

            foreach (var sceneGuid in sceneGuids)
            {
                string path = AssetDatabase.GUIDToAssetPath(sceneGuid);
                scenePaths.Add(path);
            }

            foreach (string scenePath in scenePaths)
            {
                EditorSceneManager.OpenScene(scenePath);
                GameObject targetObject = GameObject.Find(gameObjectName);

                if (targetObject != null)
                {
                    GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab, targetObject.transform);
                    instance.transform.SetParent(targetObject.transform);
                    Debug.Log($"Added prefab to GameObject in scene: {scenePath}");
                    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                }

                EditorSceneManager.SaveOpenScenes();
            }

            Debug.Log("Finished adding prefab to all scenes.");
        }
    }
}
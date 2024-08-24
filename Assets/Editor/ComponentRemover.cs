using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editor
{
    public class ComponentRemover : EditorWindow
    {
        private string gameObjectName;
        private string componentName;

        [MenuItem("Tools/Component Remover")]
        public static void ShowWindow()
        {
            GetWindow<ComponentRemover>("Component Remover");
        }

        void OnGUI()
        {
            GUILayout.Label("Remove Component from GameObject", EditorStyles.boldLabel);

            gameObjectName = EditorGUILayout.TextField("GameObject Name", gameObjectName);
            componentName = EditorGUILayout.TextField("Component Name", componentName);

            if (GUILayout.Button("Remove Component"))
            {
                RemoveComponentFromAllScenes(gameObjectName, componentName);
            }
        }

        private void RemoveComponentFromAllScenes(string goName, string compName)
        {
            if (string.IsNullOrEmpty(goName) || string.IsNullOrEmpty(compName))
            {
                Debug.LogError("GameObject name and Component name must be provided.");
                return;
            }

            var scenePaths = new List<string>();
            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled)
                {
                    scenePaths.Add(scene.path);
                }
            }

            foreach (var scenePath in scenePaths)
            {
                EditorSceneManager.OpenScene(scenePath);

                GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
                foreach (var go in allGameObjects)
                {
                    if (go.name == goName)
                    {
                        var component = go.GetComponent(compName);
                        if (component != null)
                        {
                            DestroyImmediate(component);
                            Debug.Log($"Removed {compName} from {goName} in scene {scenePath}");
                        }
                    }
                }

                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            }

            AssetDatabase.SaveAssets();
            Debug.Log("Component removal complete.");
        }
    }
}
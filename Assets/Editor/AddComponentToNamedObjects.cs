using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    public class AddComponentToNamedObjects : EditorWindow
    {
        private string objectName = "Enter GameObject Name";
        private MonoScript componentScript;

        [MenuItem("Tools/Add Component To Named Objects")]
        public static void ShowWindow()
        {
            GetWindow<AddComponentToNamedObjects>("Add Component To Named Objects");
        }

        private void OnGUI()
        {
            GUILayout.Label("Add Component To Named Objects", EditorStyles.boldLabel);

            objectName = EditorGUILayout.TextField("GameObject Name", objectName);
            componentScript = (MonoScript)EditorGUILayout.ObjectField("Component Script", componentScript, typeof(MonoScript), false);

            if (GUILayout.Button("Add Component"))
            {
                AddComponentToAllNamedObjects();
            }
        }

        private void AddComponentToAllNamedObjects()
        {
            if (string.IsNullOrEmpty(objectName) || componentScript == null)
            {
                Debug.LogError("GameObject Name and Component Script must be provided.");
                return;
            }

            Type componentType = componentScript.GetClass();
            if (componentType == null || !componentType.IsSubclassOf(typeof(MonoBehaviour)))
            {
                Debug.LogError("The selected script is not a valid MonoBehaviour.");
                return;
            }

            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled)
                {
                    EditorSceneManager.OpenScene(scene.path);
                    GameObject[] allObjects = FindObjectsOfType<GameObject>();

                    foreach (GameObject obj in allObjects)
                    {
                        if (obj.name == objectName)
                        {
                            if (obj.GetComponent(componentType) == null)
                            {
                                obj.AddComponent(componentType);
                                Debug.Log($"Added {componentType.Name} to {obj.name} in scene {scene.path}");
                            }
                        }
                    }

                    EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
                    EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
                }
            }

            Debug.Log("Component addition complete.");
        }
    }
}
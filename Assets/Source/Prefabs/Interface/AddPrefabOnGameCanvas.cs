using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddPrefabOnGameCanvas : EditorWindow
{
    private GameObject prefabToAdd;

    [MenuItem("Tools/Add Prefab to Game Canvas")]
    public static void ShowWindow()
    {
        GetWindow<AddPrefabOnGameCanvas>("Add Prefab to Game Canvas");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Prefab to Add", EditorStyles.boldLabel);
        prefabToAdd = (GameObject)EditorGUILayout.ObjectField("Prefab", prefabToAdd, typeof(GameObject), false);

        if (GUILayout.Button("Add Prefab"))
        {
            if (prefabToAdd != null)
            {
                AddPrefabToAllGameCanvas();
            }
            else
            {
                EditorUtility.DisplayDialog("Error", "Please select a prefab to add.", "OK");
            }
        }
    }

    private void AddPrefabToAllGameCanvas()
    {
        string[] scenePaths = AssetDatabase.FindAssets("t:Scene");
        
        foreach (string scenePath in scenePaths)
        {
            string fullPath = AssetDatabase.GUIDToAssetPath(scenePath);
            Scene scene = EditorSceneManager.OpenScene(fullPath, OpenSceneMode.Single);

            GameObject gameCanvas = GameObject.Find("Game Canvas");
            if (gameCanvas != null)
            {
                GameObject newPrefabInstance = (GameObject)PrefabUtility.InstantiatePrefab(prefabToAdd);
                newPrefabInstance.transform.SetParent(gameCanvas.transform, false);
                EditorSceneManager.MarkSceneDirty(scene);
                EditorSceneManager.SaveScene(scene);
                Debug.Log($"Prefab added to Game Canvas in scene: {scene.name}");
            }
        }

        AssetDatabase.SaveAssets();
    }
}
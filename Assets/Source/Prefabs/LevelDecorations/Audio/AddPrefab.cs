using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.IO;

public class AddPrefab : EditorWindow
{
    private GameObject prefab;

    [MenuItem("Tools/Add Prefab to All Scenes")]
    public static void ShowWindow()
    {
        GetWindow<AddPrefab>("Add Prefab to All Scenes");
    }

    private void OnGUI()
    {
        GUILayout.Label("Add Prefab to All Scenes", EditorStyles.boldLabel);

        prefab = (GameObject)EditorGUILayout.ObjectField("Prefab to Add", prefab, typeof(GameObject), false);

        GUILayout.Space(20);

        if (GUILayout.Button("Add Prefab to All Scenes"))
        {
            if (prefab == null)
            {
                EditorUtility.DisplayDialog("Prefab Not Set", "Please set a prefab to add.", "OK");
                return;
            }

            List<string> scenePaths = GetAllScenePaths();

            foreach (string path in scenePaths)
            {
                AddPrefabToScene(path, prefab);
            }

            EditorUtility.DisplayDialog("Operation Complete", "Prefab has been added to all scenes.", "OK");
        }
    }

    private List<string> GetAllScenePaths()
    {
        List<string> scenePaths = new List<string>();
        string[] guids = AssetDatabase.FindAssets("t:Scene");

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            scenePaths.Add(path);
        }

        return scenePaths;
    }

    private void AddPrefabToScene(string scenePath, GameObject prefab)
    {
        SceneAsset sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);

        if (sceneAsset == null)
        {
            Debug.LogError("Scene not found: " + scenePath);
            return;
        }

        EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
        PrefabUtility.InstantiatePrefab(prefab);
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        EditorSceneManager.SaveOpenScenes();
    }
}
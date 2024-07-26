using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteGameObjectsWithName : EditorWindow
{
    private string objectNameToDelete;

    [MenuItem("Tools/Delete GameObjects With Name")]
    public static void ShowWindow()
    {
        GetWindow<DeleteGameObjectsWithName>("Delete GameObjects With Name");
    }

    private void OnGUI()
    {
        GUILayout.Label("Enter the name of the GameObjects to delete:", EditorStyles.boldLabel);
        objectNameToDelete = EditorGUILayout.TextField("Name", objectNameToDelete);

        if (GUILayout.Button("Delete GameObjects"))
        {
            DeleteGameObjects();
        }
    }

    private void DeleteGameObjects()
    {
        if (string.IsNullOrEmpty(objectNameToDelete))
        {
            Debug.LogError("Object name to delete is empty.");
            return;
        }

        string[] allScenePaths = AssetDatabase.FindAssets("t:Scene");
        foreach (string sceneGUID in allScenePaths)
        {
            string scenePath = AssetDatabase.GUIDToAssetPath(sceneGUID);
            Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

            GameObject gameObjectToDelete = GameObject.Find(objectNameToDelete);
            if (gameObjectToDelete != null)
            {
                DestroyImmediate(gameObjectToDelete);
                Debug.Log($"Deleted {objectNameToDelete} from scene {scene.name}");
            }

            EditorSceneManager.SaveScene(scene);
        }

        Debug.Log("Completed deleting GameObjects.");
    }
}
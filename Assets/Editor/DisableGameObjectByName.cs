using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class DisableGameObjectByName : EditorWindow
{
    private string gameObjectName = "Enter GameObject Name";

    [MenuItem("Tools/Disable GameObject By Name")]
    public static void ShowWindow()
    {
        GetWindow<DisableGameObjectByName>("Disable GameObject By Name");
    }

    private void OnGUI()
    {
        GUILayout.Label("Disable GameObject by Name in All Scenes", EditorStyles.boldLabel);

        gameObjectName = EditorGUILayout.TextField("GameObject Name", gameObjectName);

        if (GUILayout.Button("Disable GameObject in All Scenes"))
        {
            EnableGameObjectInAllScenes();
        }
    }

    private void EnableGameObjectInAllScenes()
    {
        if (string.IsNullOrEmpty(gameObjectName))
        {
            Debug.LogError("GameObject Name is not specified.");
            return;
        }

        string[] sceneGuids = AssetDatabase.FindAssets("t:Scene");

        foreach (string sceneGuid in sceneGuids)
        {
            string scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);
            Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

            GameObject[] rootObjects = scene.GetRootGameObjects();
            foreach (GameObject rootObject in rootObjects)
            {
                EnableGameObjectInChildren(rootObject.transform);
            }

            EditorSceneManager.SaveScene(scene);
        }

        Debug.Log($"Disabled GameObject named '{gameObjectName}' in all scenes.");
    }

    private void EnableGameObjectInChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name == gameObjectName)
            {
                child.gameObject.SetActive(false);
                Debug.Log($"Disabled GameObject '{gameObjectName}' in scene '{parent.gameObject.scene.name}'.");
            }

            EnableGameObjectInChildren(child);
        }
    }
}
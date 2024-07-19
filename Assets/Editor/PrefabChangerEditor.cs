using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Linq;

public class PrefabChangerEditor : EditorWindow
{
    
    private string gameObjectName = "Enter GameObject Name";
    private GameObject newPrefab;

    [MenuItem("Tools/Prefab Reference Changer")]
    public static void ShowWindow()
    {
        GetWindow<PrefabChangerEditor>("Prefab Reference Changer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Prefab Reference Changer", EditorStyles.boldLabel);

        gameObjectName = EditorGUILayout.TextField("GameObject Name", gameObjectName);
        newPrefab = (GameObject)EditorGUILayout.ObjectField("New Prefab", newPrefab, typeof(GameObject), false);

        if (GUILayout.Button("Change Prefab Reference in All Scenes"))
        {
            ChangePrefabReferenceInAllScenes();
        }
    }

    private void ChangePrefabReferenceInAllScenes()
    {
        if (newPrefab == null)
        {
            Debug.LogError("New Prefab is not assigned.");
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
                ChangePrefabReferenceInChildren(rootObject.transform, scenePath);
            }

            EditorSceneManager.SaveScene(scene);
        }

        Debug.Log("Prefab reference change complete in all scenes.");
    }

    private void ChangePrefabReferenceInChildren(Transform parent, string scenePath)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name == gameObjectName)
            {
                ChangePrefabReference(child.gameObject, scenePath);
            }

            ChangePrefabReferenceInChildren(child, scenePath);
        }
    }

    private void ChangePrefabReference(GameObject targetObject, string scenePath)
    {
        GameObject prefabRoot = (GameObject)PrefabUtility.GetCorrespondingObjectFromSource(targetObject);
        if (prefabRoot != null)
        {
            GameObject newInstance = (GameObject)PrefabUtility.InstantiatePrefab(newPrefab, targetObject.transform.parent);
            newInstance.transform.SetPositionAndRotation(targetObject.transform.position, targetObject.transform.rotation);
            newInstance.transform.localScale = targetObject.transform.localScale;

            DestroyImmediate(targetObject);
            PrefabUtility.UnpackPrefabInstance(newInstance, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
            Debug.Log($"Changed prefab reference of '{gameObjectName}' to '{newPrefab.name}' in scene '{scenePath}'.");
        }
        else
        {
            Debug.LogWarning($"GameObject '{gameObjectName}' in scene '{scenePath}' is not a prefab instance.");
        }
    }
}
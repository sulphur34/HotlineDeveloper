using UnityEngine;
using UnityEditor;
using System.IO;

public class AssignTransformsEditor : Editor
{
    [MenuItem("Tools/Assign Transforms to ScriptableObjects")]
    static void AssignFolders
        ()
    {
        // Let the user select the folder containing the ScriptableObjects
        string scriptableObjectsFolder = EditorUtility.OpenFolderPanel("Select ScriptableObjects Folder", "", "");
        // Let the user select the folder containing the Transform prefabs
        string transformsFolder = EditorUtility.OpenFolderPanel("Select Transform Prefabs Folder", "", "");

        if (string.IsNullOrEmpty(scriptableObjectsFolder) || string.IsNullOrEmpty(transformsFolder))
        {
            Debug.LogError("Folder selection was canceled.");
            return;
        }

        // Convert the selected folder paths to relative paths
        scriptableObjectsFolder = ConvertToRelativePath(scriptableObjectsFolder);
        transformsFolder = ConvertToRelativePath(transformsFolder);

        // Get all ScriptableObject assets in the selected folder
        string[] scriptableObjectGUIDs = AssetDatabase.FindAssets("t:ScriptableObject", new[] { scriptableObjectsFolder });
        // Get all Transform prefabs in the selected folder
        string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab", new[] { transformsFolder });

        foreach (string scriptableObjectGUID in scriptableObjectGUIDs)
        {
            string path = AssetDatabase.GUIDToAssetPath(scriptableObjectGUID);
            ScriptableObject scriptableObject = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
            
            // Assuming your ScriptableObject has a property named "TransformField" with [field: SerializeField]
            SerializedObject serializedObject = new SerializedObject(scriptableObject);
            SerializedProperty transformProperty = serializedObject.FindProperty("<SpawnPoint>k__BackingField");

            if (transformProperty == null)
            {
                Debug.LogWarning($"No property 'SpawnPoint' found in {scriptableObject.name}. Available properties are:");
                PrintAllProperties(serializedObject);
                continue;
            }

            if (transformProperty.propertyType == SerializedPropertyType.ObjectReference)
            {
                string scriptableObjectName = Path.GetFileNameWithoutExtension(path);
                int scriptableObjectNumber = ExtractNumberFromName(scriptableObjectName);

                foreach (string prefabGUID in prefabGUIDs)
                {
                    string prefabPath = AssetDatabase.GUIDToAssetPath(prefabGUID);
                    GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                    string prefabName = prefab.name;
                    int prefabNumber = ExtractNumberFromName(prefabName);

                    if (scriptableObjectNumber == prefabNumber)
                    {
                        transformProperty.objectReferenceValue = prefab.transform;
                        serializedObject.ApplyModifiedProperties();
                        Debug.Log($"Assigned {prefab.name} to {scriptableObjectName}");
                        break;
                    }
                }
            }
        }
    }

    static int ExtractNumberFromName(string name)
    {
        int number = 0;
        string numberString = string.Empty;

        foreach (char c in name)
        {
            if (char.IsDigit(c))
            {
                numberString += c;
            }
        }

        if (int.TryParse(numberString, out number))
        {
            return number;
        }

        return -1; // Return -1 if no number is found
    }

    static string ConvertToRelativePath(string absolutePath)
    {
        if (absolutePath.StartsWith(Application.dataPath))
        {
            return "Assets" + absolutePath.Substring(Application.dataPath.Length);
        }
        return absolutePath;
    }

    static void PrintAllProperties(SerializedObject serializedObject)
    {
        SerializedProperty property = serializedObject.GetIterator();
        while (property.NextVisible(true))
        {
            Debug.Log($"{property.name} ({property.propertyType})");
        }
    }
}
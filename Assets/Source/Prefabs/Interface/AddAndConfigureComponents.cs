using Modules.LevelsSystem;
using Modules.ScoreSystem;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AddAndConfigureComponents : EditorWindow
{
    [MenuItem("Tools/Add and Configure Components")]
    public static void ShowWindow()
    {
        GetWindow<AddAndConfigureComponents>("Add and Configure Components");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Add Components and Configure"))
        {
            AddComponentsAndConfigure();
        }
    }

    private static void AddComponentsAndConfigure()
    {
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            EnemyTracker enemyTracker = obj.GetComponent<EnemyTracker>();
            if (enemyTracker != null)
            {
                // Add ScoreCounterView and LevelConditionManager components if they don't exist
                ScoreCounterView scoreCounterView = obj.GetComponent<ScoreCounterView>();
                if (scoreCounterView == null)
                {
                    scoreCounterView = obj.AddComponent<ScoreCounterView>();
                }

                if (obj.GetComponent<LevelConditionManager>() == null)
                {
                    obj.AddComponent<LevelConditionManager>();
                }

                // Find ScoreLabel component in the scene
                ScoreLabel scoreLabel = FindObjectOfType<ScoreLabel>();
                if (scoreLabel != null)
                {
                    // Assign the ScoreLabel component to the _scoreLabel field of the ScoreCounterView component
                    SerializedObject serializedObject = new SerializedObject(scoreCounterView);
                    SerializedProperty scoreLabelProperty = serializedObject.FindProperty("_scoreLabel");
                    scoreLabelProperty.objectReferenceValue = scoreLabel;
                    serializedObject.ApplyModifiedProperties();
                }
                else
                {
                    Debug.LogWarning("ScoreLabel component not found in the scene.");
                }

                // Remove missing scripts
                RemoveMissingScripts(obj);

                // Mark the scene as dirty to ensure the changes are saved
                EditorUtility.SetDirty(obj);
            }
        }

        // Save changes to the scene
        EditorSceneManager.MarkAllScenesDirty();
        AssetDatabase.SaveAssets();
    }

    private static void RemoveMissingScripts(GameObject gameObject)
    {
        Component[] components = gameObject.GetComponents<Component>();
        SerializedObject serializedObject = new SerializedObject(gameObject);
        SerializedProperty prop = serializedObject.FindProperty("m_Component");

        int r = 0;
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i] == null)
            {
                prop.DeleteArrayElementAtIndex(i - r);
                r++;
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}
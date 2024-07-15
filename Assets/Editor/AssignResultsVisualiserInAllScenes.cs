using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using Modules.ScoreSystem;
using Source.Modules.GUISystem;
using UnityEngine.SceneManagement;

public class AssignResultsVisualiserInAllScenes : EditorWindow
{
    [MenuItem("Tools/Assign ResultsVisualiser in All Scenes")]
    public static void ShowWindow()
    {
        GetWindow<AssignResultsVisualiserInAllScenes>("Assign ResultsVisualiser in All Scenes");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Assign ResultsVisualiser"))
        {
            AssignResultsVisualiserInAllScenesMethod();
        }
    }

    private void AssignResultsVisualiserInAllScenesMethod()
    {
        string[] sceneGuids = AssetDatabase.FindAssets("t:Scene");
        List<string> scenePaths = sceneGuids.Select(AssetDatabase.GUIDToAssetPath).ToList();

        foreach (string scenePath in scenePaths)
        {
            SceneSetup[] previousSceneSetup = EditorSceneManager.GetSceneManagerSetup();
            Scene openScene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

            GameObject levelHandler = GameObject.Find("LevelHandler");
            if (levelHandler != null)
            {
                ResultsVisualiser resultsVisualiser = GameObject.FindObjectOfType<ResultsVisualiser>();
                ScoreCounterView scoreCounterView = levelHandler.GetComponent<ScoreCounterView>();

                if (resultsVisualiser != null && scoreCounterView != null)
                {
                    SerializedObject serializedObject = new SerializedObject(scoreCounterView);
                    SerializedProperty property = serializedObject.FindProperty("_resultsVisualiser");

                    if (property != null && property.propertyType == SerializedPropertyType.ObjectReference)
                    {
                        property.objectReferenceValue = resultsVisualiser;
                        serializedObject.ApplyModifiedProperties();
                        Debug.Log($"Assigned ResultsVisualiser to ScoreCounterView in scene {scenePath}.");
                    }
                    else
                    {
                        Debug.LogError($"Field '_resultsVisualiser' not found or is not an ObjectReference in component 'ScoreCounterView' on GameObject 'LevelHandler' in scene '{scenePath}'.");
                    }
                }
                else
                {
                    if (scoreCounterView == null)
                    {
                        Debug.LogWarning($"Component 'ScoreCounterView' not found on GameObject 'LevelHandler' in scene '{scenePath}'.");
                    }
                    else
                    {
                        Debug.LogWarning($"No 'ResultsVisualiser' components found in scene '{scenePath}'.");
                    }
                }
            }
            else
            {
                Debug.LogWarning($"GameObject 'LevelHandler' not found in scene '{scenePath}'.");
            }

            EditorSceneManager.MarkSceneDirty(openScene);
            EditorSceneManager.SaveScene(openScene);
            EditorSceneManager.RestoreSceneManagerSetup(previousSceneSetup);
        }

        Debug.Log("Finished assigning ResultsVisualiser in all scenes.");
    }
}
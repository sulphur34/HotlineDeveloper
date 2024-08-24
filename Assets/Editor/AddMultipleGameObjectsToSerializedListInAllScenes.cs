using System.Collections.Generic;
using Game.Scripts.CompositRoot;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editor
{
    public class AddMultipleGameObjectsToSerializedListInAllScenes : EditorWindow
    {
        private string[] gameObjectNames;
        private string levelCompositeRootName = "CompositionRoot";
        private string gameObjectNamesInput = "";

        [MenuItem("Tools/Add Multiple GameObjects to Serialized List in All Scenes")]
        public static void ShowWindow()
        {
            GetWindow<AddMultipleGameObjectsToSerializedListInAllScenes>("Add Multiple GameObjects to Serialized List");
        }

        private void OnGUI()
        {
            GUILayout.Label("Add Multiple GameObjects to Serialized List in All Scenes", EditorStyles.boldLabel);

            gameObjectNamesInput = EditorGUILayout.TextField("GameObject Names (comma separated)", gameObjectNamesInput);
            levelCompositeRootName = EditorGUILayout.TextField("Level Composite Root Name", levelCompositeRootName);

            if (GUILayout.Button("Add GameObjects to List in All Scenes"))
            {
                gameObjectNames = gameObjectNamesInput.Split(',');
                for (int i = 0; i < gameObjectNames.Length; i++)
                {
                    gameObjectNames[i] = gameObjectNames[i].Trim();
                }
                AddGameObjectsToAutoInjectListInAllScenes(gameObjectNames, levelCompositeRootName);
            }
        }

        private void AddGameObjectsToAutoInjectListInAllScenes(string[] gameObjectNames, string levelCompositeRootName)
        {
            string[] sceneGuids = AssetDatabase.FindAssets("t:Scene");
            List<string> scenePaths = new List<string>();

            foreach (var sceneGuid in sceneGuids)
            {
                string path = AssetDatabase.GUIDToAssetPath(sceneGuid);
                scenePaths.Add(path);
            }

            foreach (string scenePath in scenePaths)
            {
                EditorSceneManager.OpenScene(scenePath);
                GameObject levelCompositeRootObject = GameObject.Find(levelCompositeRootName);

                if (levelCompositeRootObject != null)
                {
                    LevelCompositRoot levelCompositeRoot = levelCompositeRootObject.GetComponent<LevelCompositRoot>();

                    if (levelCompositeRoot != null)
                    {
                        SerializedObject serializedObject = new SerializedObject(levelCompositeRoot);
                        SerializedProperty autoInjectGameObjects = serializedObject.FindProperty("autoInjectGameObjects");

                        if (autoInjectGameObjects != null)
                        {
                            foreach (string gameObjectName in gameObjectNames)
                            {
                                GameObject targetObject = GameObject.Find(gameObjectName);

                                if (targetObject != null)
                                {
                                    bool alreadyExists = false;

                                    for (int i = 0; i < autoInjectGameObjects.arraySize; i++)
                                    {
                                        if (autoInjectGameObjects.GetArrayElementAtIndex(i).objectReferenceValue == targetObject)
                                        {
                                            alreadyExists = true;
                                            break;
                                        }
                                    }

                                    if (!alreadyExists)
                                    {
                                        autoInjectGameObjects.arraySize++;
                                        autoInjectGameObjects.GetArrayElementAtIndex(autoInjectGameObjects.arraySize - 1).objectReferenceValue = targetObject;
                                        serializedObject.ApplyModifiedProperties();
                                        Debug.Log($"Added {gameObjectName} to autoInjectGameObjects list of {levelCompositeRootName} in scene {scenePath}.");
                                    }
                                    else
                                    {
                                        Debug.Log($"{gameObjectName} already exists in autoInjectGameObjects list of {levelCompositeRootName} in scene {scenePath}.");
                                    }
                                }
                                else
                                {
                                    Debug.LogWarning($"GameObject with name '{gameObjectName}' not found in scene {scenePath}.");
                                }
                            }
                        }
                    }
                }

                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                EditorSceneManager.SaveOpenScenes();
            }

            Debug.Log("Finished adding GameObjects to all scenes.");
        }
    }
}
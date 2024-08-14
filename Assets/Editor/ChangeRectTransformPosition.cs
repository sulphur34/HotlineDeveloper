using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ChangeRectTransformPosition : EditorWindow
{
    string objectName = "YourObjectName";
    float newXPosition = 0f;

    [MenuItem("Tools/Change RectTransform Position")]
    public static void ShowWindow()
    {
        GetWindow<ChangeRectTransformPosition>("Change RectTransform Position");
    }

    void OnGUI()
    {
        GUILayout.Label("Set New RectTransform X Position", EditorStyles.boldLabel);

        objectName = EditorGUILayout.TextField("Object Name", objectName);
        newXPosition = EditorGUILayout.FloatField("New X Position", newXPosition);

        if (GUILayout.Button("Change Position"))
        {
            ChangePositionInAllScenes();
        }
    }

    void ChangePositionInAllScenes()
    {
        // Получаем все пути ко всем сценам
        string[] sceneGuids = AssetDatabase.FindAssets("t:Scene");
        foreach (string sceneGuid in sceneGuids)
        {
            string scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);

            // Загружаем сцену
            Scene scene = EditorSceneManager.OpenScene(scenePath);

            // Ищем объект с заданным именем
            GameObject obj = GameObject.Find(objectName);
            if (obj != null)
            {
                RectTransform rectTransform = obj.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    // Меняем позицию по X
                    Vector3 newPosition = rectTransform.anchoredPosition;
                    newPosition.x = newXPosition;
                    rectTransform.anchoredPosition = newPosition;

                    Debug.Log($"Changed position of {objectName} in scene {scenePath}");

                    // Помечаем сцену как измененную
                    EditorSceneManager.MarkSceneDirty(scene);
                }
            }

            // Сохраняем сцену, если были изменения
            EditorSceneManager.SaveScene(scene);
        }

        AssetDatabase.SaveAssets();
        Debug.Log("Position change completed in all scenes.");
    }
}
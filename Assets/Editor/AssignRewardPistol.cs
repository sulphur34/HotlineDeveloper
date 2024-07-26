using System.Linq;
using Source.Modules.AdvertisementSystem;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AssignRewardPistol : EditorWindow
{
    [MenuItem("Tools/Assign Reward Pistol")]
    private static void AssignRewardPistolToAllScenes()
    {
        // Get the current active scene so we can return to it later
        Scene currentScene = SceneManager.GetActiveScene();

        // Get all the scene paths
        string[] scenePaths = AssetDatabase.FindAssets("t:Scene")
            .Select(AssetDatabase.GUIDToAssetPath)
            .ToArray();

        foreach (string scenePath in scenePaths)
        {
            // Open the scene
            Scene scene = EditorSceneManager.OpenScene(scenePath);

            // Find all ADWeaponRewardButton components in the scene
            ADWeaponRewardButton[] rewardButtons = GameObject.FindObjectsOfType<ADWeaponRewardButton>(true);

            // Find the disabled RewardPistol GameObject
            GameObject rewardPistol = Resources.FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(go => go.name == "RewardPistol");

            if (rewardPistol != null)
            {
                foreach (var rewardButton in rewardButtons)
                {
                    // Assign the RewardPistol to the _weaponGameobject field
                    SerializedObject serializedObject = new SerializedObject(rewardButton);
                    SerializedProperty weaponGameObjectProperty = serializedObject.FindProperty("_weaponGameobject");
                    weaponGameObjectProperty.objectReferenceValue = rewardPistol;
                    serializedObject.ApplyModifiedProperties();
                }

                // Mark the scene as dirty to ensure changes are saved
                EditorSceneManager.MarkSceneDirty(scene);
            }
            else
            {
                Debug.LogWarning($"RewardPistol not found in scene {scenePath}");
            }

            // Save the scene
            EditorSceneManager.SaveScene(scene);
        }

        // Reopen the original scene
        EditorSceneManager.OpenScene(currentScene.path);

        Debug.Log("Assignment complete");
    }
}

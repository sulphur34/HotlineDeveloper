using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class PlayerPrefsResetEditor : EditorWindow
    {
        [MenuItem("Tools/Reset PlayerPrefs")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(PlayerPrefsResetEditor));
        }

        private void OnGUI()
        {
            GUILayout.Label("PlayerPrefs Reset Tool", EditorStyles.boldLabel);

            if (GUILayout.Button("Reset All PlayerPrefs"))
            {
                if (EditorUtility.DisplayDialog("Reset PlayerPrefs", "Are you sure you want to reset all PlayerPrefs? This action cannot be undone.", "Yes", "No"))
                {
                    PlayerPrefs.DeleteAll();
                    PlayerPrefs.Save();
                    Debug.Log("All PlayerPrefs have been reset.");
                }
            }
        }
    }
}
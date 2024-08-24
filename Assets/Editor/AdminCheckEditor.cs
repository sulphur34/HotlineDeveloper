using System.Security.Principal;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class AdminCheckEditor : EditorWindow
    {
        [MenuItem("Tools/Check Admin Rights")]
        public static void ShowWindow()
        {
            GetWindow<AdminCheckEditor>("Check Admin Rights");
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Check if Running as Administrator"))
            {
                bool isAdmin = IsRunningAsAdministrator();
                if (isAdmin)
                {
                    Debug.Log("Unity Editor is running as Administrator.");
                }
                else
                {
                    Debug.LogWarning("Unity Editor is NOT running as Administrator.");
                }
            }
        }

        private bool IsRunningAsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
    }
}
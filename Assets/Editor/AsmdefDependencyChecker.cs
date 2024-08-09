using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AsmdefDependencyChecker : MonoBehaviour
{
    [MenuItem("Tools/Check Asmdef Dependencies")]
    public static void CheckAsmdefDependencies()
    {
        string[] asmdefFiles = Directory.GetFiles(Application.dataPath, "*.asmdef", SearchOption.AllDirectories);
        Dictionary<string, List<string>> dependencyGraph = new Dictionary<string, List<string>>();

        foreach (string asmdefFile in asmdefFiles)
        {
            string jsonContent = File.ReadAllText(asmdefFile);
            Asmdef asmdef = JsonUtility.FromJson<Asmdef>(jsonContent);
            string asmdefName = Path.GetFileNameWithoutExtension(asmdefFile);
            dependencyGraph[asmdefName] = asmdef.references.ToList();
        }

        List<string> visited = new List<string>();
        List<string> stack = new List<string>();

        foreach (var asmdef in dependencyGraph.Keys)
        {
            if (DetectCycle(asmdef, dependencyGraph, visited, stack))
            {
                Debug.LogError("Cyclic dependency detected involving: " + string.Join(", ", stack));
                return;
            }
        }

        Debug.Log("No cyclic dependencies detected.");
    }

    private static bool DetectCycle(string asmdef, Dictionary<string, List<string>> dependencyGraph, List<string> visited, List<string> stack)
    {
        if (stack.Contains(asmdef))
        {
            stack.Add(asmdef);
            return true;
        }

        if (visited.Contains(asmdef))
        {
            return false;
        }

        visited.Add(asmdef);
        stack.Add(asmdef);

        foreach (var dep in dependencyGraph[asmdef])
        {
            if (DetectCycle(dep, dependencyGraph, visited, stack))
            {
                return true;
            }
        }

        stack.Remove(asmdef);
        return false;
    }

    [System.Serializable]
    public class Asmdef
    {
        public string name;
        public string[] references;
    }
}
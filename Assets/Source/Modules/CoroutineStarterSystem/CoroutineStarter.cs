using System.Collections;
using UnityEngine;

namespace Modules.CoroutineStarterSystem
{
    public class CoroutineStarter : MonoBehaviour
    {
        public void StartRoutine(IEnumerator routine)
        {
            StartCoroutine(routine);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GameobjectEnableTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _triggeredElements;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var element in _triggeredElements)
            element.SetActive(true);

        GetComponent<Collider>().enabled = false;
    }
}
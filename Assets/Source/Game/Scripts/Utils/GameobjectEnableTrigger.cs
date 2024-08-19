using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Utils
{
    [RequireComponent(typeof(Collider))]
    public class GameobjectEnableTrigger : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _triggeredElements;
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            foreach (var element in _triggeredElements)
                element.SetActive(true);

            _collider.enabled = false;
        }
    }
}
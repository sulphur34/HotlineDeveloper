using UnityEngine;

namespace Modules.Teleport
{
    [RequireComponent(typeof(Collider))]
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private Transform _destination;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterController characterController))
            {
                characterController.enabled = false;
                other.transform.position = _destination.position;
                characterController.enabled = true;
            }
        }
    }
}
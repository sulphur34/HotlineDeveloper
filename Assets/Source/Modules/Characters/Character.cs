using Modules.MoveSystem;
using Source.Modules.InputSystem;
using UnityEngine;
using VContainer;

namespace Modules.Characters
{
    [RequireComponent(typeof(IMovable))]
    public class Character : MonoBehaviour
    {
        private IMovable _movable;
        
        [Inject]
        public void Construct(InputScheme inputScheme)
        {
            Debug.Log("VContainer on Character");
            _movable = GetComponent<IMovable>();
        }
    }
}
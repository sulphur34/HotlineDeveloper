using Modules.MoveSystem;
using UnityEngine;

namespace Modules.MoveSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class TestControler : MonoBehaviour
    {
        private Mover _mover;
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _mover = new Mover(_rigidbody, 15, 10);
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.W))
                _mover.MoveHorizontal(Vector2.up);
            
            if (Input.GetKey(KeyCode.A))
                _mover.MoveHorizontal(Vector2.left);
            
            if (Input.GetKey(KeyCode.D))
                _mover.MoveHorizontal(Vector2.right);
            
            if (Input.GetKey(KeyCode.S))
                _mover.MoveHorizontal(Vector2.down);

            float mouseX = Input.GetAxis("Mouse X");
            
            _mover.RotateHorizontal(mouseX);
        }
    }
}
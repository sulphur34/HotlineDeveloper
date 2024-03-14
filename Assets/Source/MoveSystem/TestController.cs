using UnityEngine;

namespace Source.MoveSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class TestControler : MonoBehaviour
    {
        private Mover _mover;
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _mover = new Mover(_rigidbody, 5, 10);
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.W))
                _mover.Move(Vector3.forward);
            
            if (Input.GetKey(KeyCode.A))
                _mover.Move(Vector3.left);
            
            if (Input.GetKey(KeyCode.D))
                _mover.Move(Vector3.right);
            
            if (Input.GetKey(KeyCode.S))
                _mover.Move(Vector3.back);

            float mouseX = Input.GetAxis("Mouse X");
            
            _mover.RotateHorizontal(mouseX);
        }
    }
}
using UnityEngine;

namespace Source.Game.Scripts.Animations
{
    public class IKFootSolverNew : MonoBehaviour
    {
        [SerializeField] private Transform _body;
        [SerializeField] private IKFootSolverNew _otherIKFootSolverNew;
        [SerializeField] private float _speed = 2;
        [SerializeField] private float _stepDistance = 0.3f;
        [SerializeField] private float _stepHeight = 0.1f;

        private Transform _transform;
        private Vector3 _bodyOldPosition;
        private Vector3 _footOldPosition;
        private Vector3 _currentPosition;
        
        private void Awake()
        {
            _transform = transform;
            _bodyOldPosition = _body.position;
            _footOldPosition = _transform.position;
        }

        private void Update()
        {
            _transform.position = _currentPosition;
            _transform.rotation = _body.rotation * Quaternion.Euler(90, 0, 0);
            
            Ray ray = new Ray(_body.position, Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit info, 10) && info.collider.TryGetComponent(out Ground ground))
            {
                Vector3 relativePoint = _body.InverseTransformPoint(info.point);
                Vector3 direction = _body.position - _bodyOldPosition;
                float distance = direction.magnitude;


            }
        }
    }
    
    
}
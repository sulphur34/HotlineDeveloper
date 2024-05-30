using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    [SerializeField] private Transform body;
    [SerializeField] private IKFootSolver otherFoot;
    [SerializeField] private float speedFactor = 2;
    [SerializeField] private float minSpeed = 2;
    [SerializeField] private float maxSpeed = 20;
    [SerializeField] private float stepDistance = 0.4f;
    [SerializeField] private float stepLength = 0.4f;
    [SerializeField] private float stepHeight = 0.2f;

    private Transform _transform;
    private float _footSpacing;
    private Vector3 _bodyOldPosition;
    private Vector3 _oldPosition;
    private Vector3 _currentPosition, _newPosition;
    private float _lerp;
    
    private void Awake()
    {
        _bodyOldPosition = body.position;
        _transform = transform;
        _footSpacing = _transform.localPosition.x;
        _currentPosition = _newPosition = _oldPosition = _transform.position;
        _lerp = 1;
    }

    void Update()
    {
        _transform.position = _currentPosition;
        _transform.rotation = body.rotation * Quaternion.Euler(90, 0, 0);

        Ray ray = new Ray(body.position + (Vector3.left * _footSpacing), Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit info, 10) && info.collider.TryGetComponent<Ground>(out Ground terrain))
        {
            Vector3 relativePoint = body.InverseTransformPoint(info.point);
            Vector3 relativeNewPos = body.InverseTransformPoint(_newPosition);
            Vector3 combinedDirection = new Vector3(relativePoint.x - relativeNewPos.x, 0, relativePoint.z - relativeNewPos.z);
            
            if (stepDistance < combinedDirection.magnitude && !otherFoot.IsMoving() && _lerp >= 1)
            {
                _lerp = 0;
                combinedDirection.Normalize();
                Vector3 worldDirection = body.TransformDirection(combinedDirection) * stepLength;
                _newPosition = info.point + worldDirection;
            }
        }

        if (_lerp < 1)
        {
            Vector3 tempPosition = Vector3.Lerp(_oldPosition, _newPosition, _lerp);
            tempPosition.y += Mathf.Sin(_lerp * Mathf.PI) * stepHeight;

            _currentPosition = tempPosition;

            float currentSpeed = (body.position - _bodyOldPosition).magnitude / Time.deltaTime;
            _lerp += Time.deltaTime * speedFactor * Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
        }
        else
        { 
            _oldPosition = _newPosition;
        }

        _bodyOldPosition = body.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_newPosition, 0.1f);
    }

    private bool IsMoving()
    {
        return _lerp < 1;
    }
}
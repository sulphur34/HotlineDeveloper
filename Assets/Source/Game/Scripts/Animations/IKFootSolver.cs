using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    [SerializeField] private Transform body;
    [SerializeField] private IKFootSolver otherFoot = default;
    [SerializeField] private float speed = 2; // Base speed for the foot solver
    [SerializeField] private float stepDistance = 0.4f;
    [SerializeField] private float stepLength = 0.4f;
    [SerializeField] private float stepHeight = 0.2f;
    [SerializeField] private Vector3 footOffset = default;

    private Transform _transform;
    private float _footSpacing;
    private Vector3 _bodyOldPosition;
    private Vector3 oldPosition;
    private Vector3 currentPosition, newPosition;
    private Vector3 oldNormal, currentNormal, newNormal;
    private float lerp;
    
    private void Start()
    {
        _bodyOldPosition = body.position;
        _transform = transform;
        _footSpacing = _transform.localPosition.x;
        currentPosition = newPosition = oldPosition = _transform.position;
        currentNormal = newNormal = oldNormal = _transform.up;
        lerp = 1;
    }

    void Update()
    {
        _transform.position = currentPosition;
        _transform.up = body.forward;

        Ray ray = new Ray(body.position + (body.right * _footSpacing), Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit info, 10) && info.collider.TryGetComponent<Terrain>(out Terrain terrain))
        {
            Vector3 relativePoint = body.InverseTransformPoint(info.point);
            Vector3 relativeNewPos = body.InverseTransformPoint(newPosition);

            // Use a combined vector to check the distance and direction on the XZ plane
            Vector3 combinedDirection = new Vector3(relativePoint.x - relativeNewPos.x, 0, relativePoint.z - relativeNewPos.z);
            if ((combinedDirection.magnitude - stepDistance) > 0 && !otherFoot.IsMoving() && lerp >= 1)
            {
                lerp = 0;
                // Normalize to get direction and scale by stepLength
                combinedDirection.Normalize();
                Vector3 worldDirection = body.TransformDirection(combinedDirection) * stepLength;

                newPosition = info.point + worldDirection + footOffset;
                newNormal = info.normal;
            }
        }

        if (lerp < 1)
        {
            Vector3 tempPosition = Vector3.Lerp(oldPosition, newPosition, lerp);
            tempPosition.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

            currentPosition = tempPosition;
            currentNormal = Vector3.Lerp(oldNormal, newNormal, lerp);

            float currentSpeed = (body.position - _bodyOldPosition).magnitude / Time.deltaTime;
            Debug.Log(currentSpeed);
            lerp += Time.deltaTime * speed * Mathf.Clamp(currentSpeed, 0.5f, 200f); // Clamp to avoid overly rapid changes
        }
        else
        {
            oldPosition = newPosition;
            oldNormal = newNormal;
        }

        _bodyOldPosition = body.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(newPosition, 0.1f);
    }

    public bool IsMoving()
    {
        return lerp < 1;
    }
}
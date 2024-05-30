using UnityEngine;
using UnityEngine.Animations.Rigging;

public class FootAnimationController : MonoBehaviour
{
    public Transform leftFootIKTarget;
    public Transform rightFootIKTarget;
    public Transform body; // Reference to the character's body (typically at the hips or spine)

    public float stepLength = 0.5f; // How far each step should go
    public float stepHeight = 0.15f; // How high the foot lifts during a step
    public float strideDuration = 0.5f; // Duration of each stride
    public float stepOffset = 0.2f; // Vertical offset to apply to the foot position after raycast

    private Vector3 leftFootStartPosition;
    private Vector3 rightFootStartPosition;
    private float leftFootTimer = 0.0f;
    private float rightFootTimer = 0.0f;
    private bool isLeftFootMoving = false;
    private bool isRightFootMoving = false;

    void Start()
    {
        leftFootStartPosition = leftFootIKTarget.position;
        rightFootStartPosition = rightFootIKTarget.position;
    }

    void Update()
    {
        MoveFeet(ref leftFootIKTarget, ref leftFootStartPosition, ref leftFootTimer, ref isLeftFootMoving);
        MoveFeet(ref rightFootIKTarget, ref rightFootStartPosition, ref rightFootTimer, ref isRightFootMoving);
    }

    void MoveFeet(ref Transform footTarget, ref Vector3 footStartPos, ref float footTimer, ref bool isFootMoving)
    {
        Vector3 horizontalDirection = body.forward * stepLength + (footTarget == leftFootIKTarget ? -body.right : body.right) * 0.2f; // Offset for left/right foot
        Vector3 desiredFootPos = body.position + horizontalDirection;

        // Use a raycast to find the correct ground position
        if (Physics.Raycast(desiredFootPos + Vector3.up * 1.0f, Vector3.down, out RaycastHit hit, 2.0f))
        {
            desiredFootPos = hit.point + Vector3.up * stepOffset; // Adjust foot position based on raycast hit
        }

        // Check if the foot should move
        if ((footTarget.position - desiredFootPos).magnitude > stepLength / 2 && !isFootMoving)
        {
            isFootMoving = true;
            footTimer = 0f;
        }

        if (isFootMoving)
        {
            footTimer += Time.deltaTime;

            // Interpolate the foot position
            float normalizedTime = footTimer / strideDuration;
            footTarget.position = Vector3.Lerp(footStartPos, desiredFootPos, normalizedTime) + Vector3.up * Mathf.Sin(normalizedTime * Mathf.PI) * stepHeight;

            if (footTimer >= strideDuration)
            {
                footTarget.position = desiredFootPos;
                footStartPos = desiredFootPos;
                isFootMoving = false;
            }
        }
    }
}
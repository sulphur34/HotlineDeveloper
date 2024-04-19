using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TestPlayerControllerResponse : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    private float _rotationSpeed;
    private Transform _transform;
    private CharacterController _characterController;
    private float _moveSpeed;

    private void Start()
    {
        _transform = transform;
        _rotationSpeed = 1;
        _moveSpeed = 5;
        _characterController = GetComponent<CharacterController>();
        _inputController.MoveReceived += OnMove;
        _inputController.RotationReceived += OnRotate;
        _inputController.AttackReceived += OnAttack;
        _inputController.PickReceived += OnPick;
        _inputController.FinishReceived += OnFinish;
        _inputController.LookReceived += OnLook;
        _inputController.LookReceived += OnLook;
    }

    private void OnFinish()
    {
        Debug.Log("Finish");
    }

    private void OnPick()
    {
        Debug.Log("Picked");
    }

    private void OnAttack()
    {
        Debug.Log("Attacked");
    }

    private void OnRotate(Vector2 direction)
    {
        Vector2 normalized = direction.normalized;
        float angleRadians = Mathf.Atan2(normalized.x, normalized.y);
        float angleDegrees = angleRadians * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, angleDegrees, 0f);
    }

    private void OnMove(Vector2 direction)
    {
        _characterController.Move(new Vector3(direction.x, 0f, direction.y) * Time.deltaTime * _moveSpeed);
    }

    private void OnLook(Vector2 direction)
    {
        if (direction.magnitude > 0)
            Debug.Log("Look");
    }
}

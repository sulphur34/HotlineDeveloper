using Modules.InputSystem.Interfaces;
using UnityEngine;
using VContainer;

public class UIAimFollower : MonoBehaviour
{
    [SerializeField] private RectTransform _parentRectTransform;
    private RectTransform rectTransform;
    private Camera _camera;
    private ILookInput _lookInput;
    private float _width;
    private float _height;


    [Inject]
    public void Construct(ILookInput lookInput)
    {
        _lookInput = lookInput;
        _lookInput.LookReceived += UpdatePosition;
        rectTransform = GetComponent<RectTransform>();
        _camera = Camera.main;
        _width = Screen.width;
        _height = Screen.height;
    }

    private void UpdatePosition(Vector2 lookPosition)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, lookPosition,
            null, out Vector2 movePos);
        rectTransform.anchoredPosition = movePos;
    }
}
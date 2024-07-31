using Modules.InputSystem.Interfaces;
using UnityEngine;
using VContainer;

public class UIAimFollower : MonoBehaviour
{
    [SerializeField] private RectTransform _parentRectTransform;
    private RectTransform rectTransform;
    private ILookInput _lookInput;


    [Inject]
    public void Construct(ILookInput lookInput)
    {
        _lookInput = lookInput;
        _lookInput.LookReceived += UpdatePosition;
        rectTransform = GetComponent<RectTransform>();
    }

    private void UpdatePosition(Vector2 lookPosition)
    {
        float width = Screen.width;
        float height = Screen.height;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, lookPosition,
            null, out Vector2 movePos);
        rectTransform.anchoredPosition = movePos;
    }
}
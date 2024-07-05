using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private RectTransform _parentRectTransform;
    private RectTransform rectTransform;
    private Camera _camera;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        _camera = Camera.main;
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 movePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, mousePosition,
            null, out movePos);
        rectTransform.anchoredPosition = movePos;
    }
}
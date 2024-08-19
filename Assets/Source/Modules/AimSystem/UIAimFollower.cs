using Modules.InputSystem.Interfaces;
using UnityEngine;
using VContainer;

namespace Modules.AimSystem
{
    public class UIAimFollower : MonoBehaviour
    {
        [SerializeField] private RectTransform _parentRectTransform;

        private RectTransform _rectTransform;

        [Inject]
        public void Construct(ILookInput lookInput)
        {
            lookInput.LookReceived += UpdatePosition;
            _rectTransform = GetComponent<RectTransform>();
        }

        private void UpdatePosition(Vector2 lookPosition)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _parentRectTransform,
                lookPosition,
                null,
                out Vector2 movePos);
            _rectTransform.anchoredPosition = movePos;
        }
    }
}
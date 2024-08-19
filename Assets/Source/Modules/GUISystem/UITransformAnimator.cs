using UnityEngine;

namespace Modules.GUISystem
{
    public class UITransformAnimator : MonoBehaviour
    {
        protected RectTransform Transform { get; private set; }

        private void Start()
        {
            Transform = GetComponent<RectTransform>();
            Animate();
        }

        protected virtual void Animate()
        {
        }
    }
}
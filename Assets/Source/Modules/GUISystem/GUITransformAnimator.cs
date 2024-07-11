using UnityEngine;

namespace Source.Modules.GUISystem
{
    public class GUITransformAnimator : MonoBehaviour
    {
        protected RectTransform Transform;

        void Start()
        {
            Transform = GetComponent<RectTransform>();
            Animate();
        }

        protected virtual void Animate()
        {
        }
    }
}
using UnityEngine;

namespace Modules.ScoreSystem
{
    public class UITransformAnimator : MonoBehaviour
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
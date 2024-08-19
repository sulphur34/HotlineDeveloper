using System;
using UnityEngine;

namespace Modules.GUISystem
{
    public class UITransformAnimator : MonoBehaviour
    {
        protected RectTransform Transform { get; private set; }

        private void Start()
        {
            Transform = GetComponent<RectTransform>();

            if (Transform == null)
                throw new NullReferenceException(
                    "RectTransform of UI element is null. Please set it in the inspector.");

            Animate();
        }

        protected virtual void Animate()
        {
        }
    }
}
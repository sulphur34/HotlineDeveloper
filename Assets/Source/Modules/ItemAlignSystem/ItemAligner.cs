using UnityEngine;

namespace Source.Modules.ItemAlignSystem
{
    public class ItemAligner : MonoBehaviour
    {
        [SerializeField] private float _minHeight = 0.3f;
        [SerializeField] private float _maxHeight = 2f;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            Vector3 position = _transform.position;
            
            if (position.y < _minHeight || position.y > _maxHeight)
            {
                position.y = Mathf.Clamp(position.y, _minHeight, _maxHeight);
                _transform.position = position;
            }
        }
    }
}
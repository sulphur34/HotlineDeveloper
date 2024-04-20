using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PickTest : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private Transform _weapon;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _leftHandPlaceholder;
    [SerializeField] private Transform _rightHandPlaceholder;
    [SerializeField] private RigBuilder _rigBuilder;
    [SerializeField] private TwoBoneIKConstraint _rightHandConstraint;
    [SerializeField] private TwoBoneIKConstraint _leftHandConstraint;
    [SerializeField] private Rigidbody _rigidbody;

    private bool _isEquipped;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _isEquipped == false)
        {
            _rigidbody.isKinematic = true;
            _weapon.SetParent(_container, false);
            _weapon.transform.rotation = Quaternion.Euler(_rotation);
            _weapon.transform.localPosition = _position;
            _rightHandConstraint.data.target = _rightHandPlaceholder;
            
            if(_leftHandPlaceholder != null)
                _leftHandConstraint.data.target = _leftHandPlaceholder;

            _isEquipped = true;
            
            _rigBuilder.Build();
        }
    }
}

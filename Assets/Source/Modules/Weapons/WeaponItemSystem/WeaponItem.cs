using Modules.Weapons.WeaponTypeSystem;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.Weapons.WeaponItemSystem
{
    public class WeaponItem : MonoBehaviour, IWeaponInfo
    {
        [SerializeField] private float _force;
        [SerializeField] private float _rotationForce;
        [SerializeField] private float _rotationZ = 90f;
        [SerializeField] private float _meleeRotationY = 0f;
        [SerializeField] private float _rangeRotationY = 90f;
        [SerializeField] private float _rotationX = 0f;
        

        private Transform _startContainer;
        private Transform _selfTransform;
        private Transform _currentContainer;
        private Rigidbody _rigidbody;
        private Collider _collider;

        private Func<bool> _attack;

        private CancellationToken _cancellationToken;
     
        [field: SerializeField] public bool IsTrackable { get; private set; } = true;
        [field: SerializeField] public Vector3 Offset { get; private set; }
        [field: SerializeField] public Transform LeftHandPlaceHolder { get; private set; }
        [field: SerializeField] public Transform RightHandPlaceHolder { get; private set; }
           
        public event Action<WeaponType> Attacked;

        public Transform SelfTransform => _selfTransform == null ? transform : _selfTransform;
        public WeaponType WeaponType { get; private set; }
        public bool IsEquipped { get; private set; }

        public void Init(Func<bool> attack, WeaponType type)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _attack = attack;
            WeaponType = type;
            _startContainer = transform.parent;
            _cancellationToken = this.GetCancellationTokenOnDestroy();
            _selfTransform = transform;
        }

        public void Attack()
        {
            if(_attack())
                Attacked?.Invoke(WeaponType);  
        }

        public void Equip(Transform container)
        {
            SetEquipped(true, container);
            _currentContainer = container;
        }

        public void Unequip()
        {
            SetEquipped(false, null);
        }

        public void Throw(Action OnThrowEndCallback)
        {
            Unequip();
            Vector3 throwDirection = _currentContainer.forward;
            Vector3 rotationDirection = WeaponType == WeaponType.Range ? _selfTransform.up : _selfTransform.forward;
            _selfTransform.rotation = Quaternion.identity;
            float rotationY = WeaponType == WeaponType.Range ?  _rangeRotationY : _meleeRotationY;
            _selfTransform.Rotate(_rotationX,rotationY,_rotationZ);
            _selfTransform.position = _currentContainer.position;
            _rigidbody.AddTorque(rotationDirection * _rotationForce, ForceMode.VelocityChange);
            _rigidbody.AddForce(throwDirection * _force, ForceMode.Impulse);
            WaitingThrowEnd(_cancellationToken, OnThrowEndCallback);
        }
        
        private async UniTask WaitingThrowEnd(CancellationToken cancellationToken, Action OnThrowEndCallback)
        {
            while (_rigidbody.IsSleeping() == false)
            {
                await UniTask.Yield(cancellationToken);
            }
            
            OnThrowEndCallback?.Invoke();
        }

        private void SetEquipped(bool value, Transform container)
        {
            IsEquipped = value;
            
            if (_collider == null)
            {
                _rigidbody = GetComponent<Rigidbody>();
                _collider = GetComponent<Collider>();
            }
                
            _collider.enabled = !value;
            var newcontainer = value ? container : _startContainer;
            
            if (newcontainer == container)
                newcontainer.localPosition = Offset;
            
            SelfTransform.SetParent(newcontainer);
            _rigidbody.isKinematic = value;
            _rigidbody.useGravity = !value;
            
            if (value)
            {
                SelfTransform.position = container.position;
                SelfTransform.forward = container.forward;
            }
        }
    }
}
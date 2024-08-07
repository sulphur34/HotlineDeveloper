using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.DamageReceiverSystem;
using Modules.Weapons.Ammunition;
using Modules.WeaponTypes;
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
        private CancellationToken _cancellationToken;
        private Func<bool> _attack;
        private Action _interrupt;
        private WeaponStrategy _weaponStrategy;

        [field: SerializeField] public bool IsTrackable { get; private set; } = true;
        [field: SerializeField] public Vector3 Offset { get; private set; }
        [field: SerializeField] public Transform LeftHandPlaceHolder { get; private set; }
        [field: SerializeField] public Transform RightHandPlaceHolder { get; private set; }
        
        public IAmmunitionView _weaponAmmunitionView { get; private set; }

        public event Action<WeaponType> Attacked;

        public Transform SelfTransform => _selfTransform == null ? transform : _selfTransform;
        public WeaponType WeaponType { get; private set; }
        public bool IsEquipped { get; private set; }

        public void Initialize(WeaponSetup weaponSetup)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _weaponStrategy = GetComponent<WeaponStrategy>();
            _weaponAmmunitionView = GetComponent<WeaponAmmunitionView>();
            _attack = weaponSetup.AttackHandler;
            _interrupt = weaponSetup.AttackInterruptHAndler;
            WeaponType = weaponSetup.WeaponType;
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
            _weaponStrategy.Equip(container);
            _currentContainer = container;
            _currentContainer = container;
        }

        public void Unequip()
        {
            Detach();
            _weaponStrategy.ClearOwner();
        }

        public void Throw()
        {
            Detach();
            Vector3 throwDirection = _currentContainer.forward;
            Vector3 rotationDirection = WeaponType == WeaponType.Range ? _selfTransform.up : _selfTransform.forward;
            _selfTransform.rotation = Quaternion.identity;
            float rotationY = WeaponType == WeaponType.Range ?  _rangeRotationY : _meleeRotationY;
            _selfTransform.Rotate(_rotationX,rotationY,_rotationZ);
            _selfTransform.position = _currentContainer.position;
            _rigidbody.AddTorque(rotationDirection * _rotationForce, ForceMode.VelocityChange);
            _rigidbody.AddForce(throwDirection * _force, ForceMode.Impulse);
            WaitingThrowEnd(_cancellationToken);
        }

        private void Detach()
        {
            _interrupt?.Invoke();
            SetEquipped(false, null);
        }
        
        private async UniTask WaitingThrowEnd(CancellationToken cancellationToken)
        {
            while (_rigidbody.IsSleeping() == false)
            {
                await UniTask.Yield(cancellationToken);
            }
            
            _weaponStrategy.ClearOwner();
        }

        private void SetEquipped(bool value, Transform container)
        {
            IsEquipped = value;
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
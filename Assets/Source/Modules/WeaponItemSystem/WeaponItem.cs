using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.DamageReceiverSystem;
using Modules.Weapons;
using Modules.Weapons.Ammunition;
using Modules.WeaponTypes;
using UnityEngine;

namespace Modules.WeaponItemSystem
{
    public class WeaponItem : MonoBehaviour, IWeaponInfo
    {
        [SerializeField] private ThrowData _throwData;
        
        private Transform _startContainer;
        private Transform _selfTransform;
        private Transform _currentContainer;
        private Rigidbody _rigidbody;
        private Collider _collider;
        private CancellationToken _cancellationToken;
        private Func<bool> _attack;
        private Action _interrupt;
        private WeaponStrategy _weaponStrategy;
        private Thrower _thrower;

        [field: SerializeField] public bool IsTrackable { get; private set; } = true;
        [field: SerializeField] public Vector3 Offset { get; private set; }
        [field: SerializeField] public Transform LeftHandPlaceHolder { get; private set; }
        [field: SerializeField] public Transform RightHandPlaceHolder { get; private set; }
        
        public IAmmunitionView WeaponAmmunitionView { get; private set; }

        public event Action<WeaponType> Attacked;
        public Transform SelfTransform => _selfTransform == null ? transform : _selfTransform;
        public WeaponType WeaponType { get; private set; }
        public bool IsEquipped { get; private set; }

        public void Initialize(WeaponSetup weaponSetup)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _weaponStrategy = GetComponent<WeaponStrategy>();
            WeaponAmmunitionView = GetComponent<WeaponAmmunitionView>();
            _attack = weaponSetup.AttackHandler;
            _interrupt = weaponSetup.AttackInterruptHandler;
            WeaponType = weaponSetup.WeaponType;
            _startContainer = transform.parent;
            _cancellationToken = this.GetCancellationTokenOnDestroy();
            _selfTransform = transform;
            _thrower = new Thrower(_throwData);
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
        }

        public void Unequip()
        {
            Detach();
            _weaponStrategy.ClearOwner();
        }

        public void Throw()
        {
            Detach();
            _thrower.SetFly(_selfTransform, _currentContainer, _rigidbody, WeaponType);
            _thrower.WaitingThrowEnd(_rigidbody, _cancellationToken, _weaponStrategy.ClearOwner);
        }

        private void Detach()
        {
            _interrupt?.Invoke();
            SetEquipped(false, null);
        }

        private void SetEquipped(bool value, Transform container)
        {
            IsEquipped = value;
            _collider.enabled = !value;
            var newContainer = value ? container : _startContainer;
            
            if (newContainer == container)
                newContainer.localPosition = Offset;
            
            SelfTransform.SetParent(newContainer);
            _rigidbody.isKinematic = value;
            _rigidbody.useGravity = !value;

            if (value == false)
                return;
            
            SelfTransform.position = container.position;
            SelfTransform.forward = container.forward;
        }
    }
}
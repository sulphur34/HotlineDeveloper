using Modules.Weapons.WeaponTypeSystem;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.Weapons.WeaponItemSystem
{
    public class WeaponItem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _force;
        [SerializeField] private float _rotationForce;

        private Transform _startContainer;

        private Action _attack;

        private CancellationToken _cancellationToken;

        [field: SerializeField] public Transform LeftHandPlaceHolder { get; private set; }

        [field: SerializeField] public Transform RightHandPlaceHolder { get; private set; }

        public event Action<Transform> Equipped;
        public event Action Thrown;

        public WeaponType Type { get; private set; }

        public bool IsEquipped { get; private set; }

        public void Init(Action attack, WeaponType type)
        {
            _attack = attack;
            Type = type;
            _startContainer = transform.parent;
            _cancellationToken = this.GetCancellationTokenOnDestroy();
        }

        public void Attack()
        {
            _attack?.Invoke();
        }

        public void Equip(Transform container)
        {
            Equipped?.Invoke(container);
            SetEquipped(true, container);
        }

        public void Throw()
        {
            SetEquipped(false, null);
            
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            
            _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
            _rigidbody.AddTorque(Vector3.up * _rotationForce);
            transform.SetParent(_startContainer);
            WaitingThrowEnd(_cancellationToken, Thrown);
        }
        
        private async UniTask WaitingThrowEnd(CancellationToken cancellationToken, Action onRecoveredCallback)
        {
            while (_rigidbody.IsSleeping() == false)
            {
                await UniTask.Yield(cancellationToken);
            }
            
            onRecoveredCallback?.Invoke();
        }

        private void SetEquipped(bool value, Transform container)
        {
            IsEquipped = value;
            transform.SetParent(container);

            if (container != null)
            {
                _rigidbody.isKinematic = true;
                _rigidbody.useGravity = false;
                transform.position = container.position;
                transform.forward = container.forward;
            }
        }
    }
}
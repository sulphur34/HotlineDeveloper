using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.WeaponsTypes;
using UnityEngine;

namespace Modules.WeaponItemSystem
{
    public class Thrower
    {
        private readonly ThrowData _throwData;

        public Thrower(ThrowData throwData)
        {
            _throwData = throwData;
        }

        public void SetFly(
            Transform selfTransform,
            Transform currentContainer,
            Rigidbody rigidbody,
            WeaponType weaponType)
        {
            SetPosition(selfTransform, currentContainer);
            SetRotation(selfTransform, weaponType);
            ApplyForces(selfTransform, currentContainer, rigidbody, weaponType);
        }

        public async UniTask WaitingThrowEnd(
            Rigidbody rigidbody,
            CancellationToken cancellationToken,
            Action onThrowEndCallback)
        {
            while (rigidbody.IsSleeping() == false)
            {
                await UniTask.Yield(cancellationToken);
            }

            onThrowEndCallback.Invoke();
        }

        private void SetPosition(Transform selfTransform, Transform currentContainer)
        {
            selfTransform.position = currentContainer.position;
        }

        private void SetRotation(Transform selfTransform, WeaponType weaponType)
        {
            selfTransform.rotation = Quaternion.identity;
            float rotationY = weaponType == WeaponType.Range ? _throwData.RangeRotationY : _throwData.MeleeRotationY;
            selfTransform.Rotate(_throwData.RotationX, rotationY, _throwData.RotationZ);
        }

        private void ApplyForces(
            Transform selfTransform,
            Transform currentContainer,
            Rigidbody rigidbody,
            WeaponType weaponType)
        {
            Vector3 throwDirection = currentContainer.forward;
            Vector3 rotationDirection = weaponType == WeaponType.Range ? selfTransform.up : selfTransform.forward;
            rigidbody.AddTorque(rotationDirection * _throwData.RotationForce, ForceMode.VelocityChange);
            rigidbody.AddForce(throwDirection * _throwData.Force, ForceMode.Impulse);
        }
    }
}
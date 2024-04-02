using System;
using UnityEngine;
using VContainer;

namespace Modules.MoveSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoverSetup : MonoBehaviour
    {
        private MoverPresenter _moverPresenter;
        private Rigidbody _rigidbody;

        [Inject]
        public void Construct(MoverConfig moverConfig, IMoveInput moveInput, IRotateInput rotateInput)
        {
            _rigidbody = GetComponent<Rigidbody>();
            RigidbodyMover rigidbodyMover = new RigidbodyMover(_rigidbody, moverConfig);
            _moverPresenter = new MoverPresenter(rigidbodyMover, moveInput, rotateInput);
        }

        public void OnDestroy()
        {
            _moverPresenter.Dispose();
        }
    }
}
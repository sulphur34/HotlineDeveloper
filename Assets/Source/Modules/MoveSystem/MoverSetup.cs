using Modules.DamageReceiverSystem;
using Modules.InputSystem.Interfaces;
using UnityEngine;
using VContainer;

namespace Modules.MoveSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class MoverSetup : MonoBehaviour
    {
        [SerializeField] private Transform _torsoRotator;
        [SerializeField] private DamageReceiverView _damageReceiverView;
        
        private MoverPresenter _moverPresenter;

        [Inject]
        public void Construct(MoverConfig moverConfig, IMoveInput moveInput, IRotateInput lookInput)
        {
            var characterController = GetComponent<CharacterController>();
            Mover mover = new Mover(characterController, transform, _torsoRotator, moverConfig);
            _moverPresenter = new MoverPresenter(mover, moveInput, lookInput);
        }

        public void OnDestroy()
        {
            _moverPresenter.Dispose();
        }
    }
}
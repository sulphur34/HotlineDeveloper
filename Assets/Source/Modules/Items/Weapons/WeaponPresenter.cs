using System;
using Modules.Items.Weapons.InputSystem;

namespace Modules.Items.Weapons
{
    internal class WeaponPresenter : IDisposable
    {
        private readonly IAttacker _attacker;
        private readonly IShotInput _input;

        internal WeaponPresenter(IAttacker attacker, IShotInput input)
        {
            _attacker = attacker;
            _input = input;
            _input.Received += OnReceived;
            _attacker.Attacked += OnAttacked;
        }

        public void Dispose()
        {
            _input.Received -= OnReceived;
            _attacker.Attacked -= OnAttacked;
        }

        protected virtual void RunAfterAttack() { }

        private void OnReceived()
        {
            _attacker.Attack();
        }

        private void OnAttacked()
        {
            RunAfterAttack();
        }
    }
}
using System;
using Modules.Items.Weapons.InputSystem;

namespace Modules.Items.Weapons
{
    internal class WeaponPresenter : IDisposable
    {
        private readonly Weapon _weapon;
        private readonly IShotInput _input;

        internal WeaponPresenter(Weapon weapon, IShotInput input)
        {
            _weapon = weapon;
            _input = input;
            _input.Received += OnReceived;
            _weapon.Attacked += OnAttacked;
        }

        public void Dispose()
        {
            _input.Received -= OnReceived;
            _weapon.Attacked -= OnAttacked;
        }

        protected virtual void RunAfterAttack() { }

        private void OnReceived()
        {
            _weapon.Attack();
        }

        private void OnAttacked()
        {
            RunAfterAttack();
        }
    }
}
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
        }

        public void Dispose()
        {
            _input.Received -= OnReceived;
            _weapon.Dispose();
        }

        private void OnReceived()
        {
            _weapon.Shot();
        }
    }
}
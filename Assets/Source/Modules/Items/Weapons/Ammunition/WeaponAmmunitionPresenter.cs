using System;

namespace Modules.Items.Weapons.Ammunition
{
    internal class WeaponAmmunitionPresenter : IDisposable
    {
        private readonly WeaponAmmunition _ammunition;
        private readonly IWeaponAmmunitionView _view;

        internal WeaponAmmunitionPresenter(WeaponAmmunition ammunition, IWeaponAmmunitionView view)
        {
            _ammunition = ammunition;
            _view = view;
            UpdateCount();

            _ammunition.CountChanged += OnCountChanged;
        }

        public void Dispose()
        {
            _ammunition.CountChanged -= OnCountChanged;
        }

        private void UpdateCount()
        {
            _view.UpdateCount(_ammunition.Count);
        }

        private void OnCountChanged()
        {
            UpdateCount();
        }
    }
}
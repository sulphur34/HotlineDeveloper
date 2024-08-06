using Modules.Weapons.Ammunition;

namespace Modules.PlayerWeaponsHandler
{
    public class AmmoUIHandler
    {
        private AmmunitionUI _ammunitionUI;
        private IAmmunitionView _currentAmmunitionView;

        public AmmoUIHandler(AmmunitionUI ammunitionUI, IAmmunitionView currentAmmunitionView)
        {
            _ammunitionUI = ammunitionUI;
            _currentAmmunitionView = currentAmmunitionView;
        }

        public void SetAmmoUI(bool isActive, IAmmunitionView ammunitionView)
        {
            if (_ammunitionUI == null)
                return;

            if (isActive)
            {
                _currentAmmunitionView = ammunitionView;
                _ammunitionUI.Activate(_currentAmmunitionView.CurrentAmmoCount);
                _ammunitionUI.Initialize(_currentAmmunitionView.AmmoIcon);
                _currentAmmunitionView.Changed += _ammunitionUI.UpdateAmmo;
            }
            else
            {
                _currentAmmunitionView.Changed -= _ammunitionUI.UpdateAmmo;
                _ammunitionUI.Deactivate();
            }
        }
    }
}
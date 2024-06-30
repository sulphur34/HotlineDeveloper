using UnityEngine;

namespace Modules.PlayerWeaponsHandler
{
    public class WeaponHandlerSetup : MonoBehaviour
    {
        [SerializeField] protected WeaponHandlerData WeaponHandlerData;
        [SerializeField] protected WeaponHandlerView WeaponHandlerView;

        protected WeaponHandlerPresenter WeaponHandlerPresenter;

        private void OnDestroy()
        {
            WeaponHandlerPresenter.Dispose();
        }
    }
}
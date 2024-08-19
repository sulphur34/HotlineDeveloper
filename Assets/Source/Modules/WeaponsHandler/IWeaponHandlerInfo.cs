using Modules.WeaponTypes;

namespace Modules.WeaponsHandler
{
    public interface IWeaponHandlerInfo
    {
        public bool IsCurrentWeaponItemEmpty { get; }

        public WeaponType CurrentWeaponType { get; }
    }
}
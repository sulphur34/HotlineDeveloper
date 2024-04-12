using Modules.Items.ItemPickSystem;
using Modules.PlayerWeaponsHandler;
using Modules.Weapons.Ammunition;
using Modules.Weapons.InputSystem;
using Modules.Weapons.Range;
using Modules.WeaponItemSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ClaudiffTestsCompositRoot : LifetimeScope
{
    [SerializeField] private RangeWeaponConfigFactory _weaponConfigFactory;
    [SerializeField] private GameObject _weaponSetupsParent;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<IItemSelectionInput>();
        builder.RegisterComponentInHierarchy<IPickable>();

        builder.RegisterInstance(_weaponConfigFactory);
        builder.RegisterComponentInHierarchy<WeaponAmmunitionView>();
        builder.RegisterEntryPoint<ShotDesktopInput>().As<IShotInput>();
        builder.RegisterEntryPoint<DesktopWeaponItemInput>().As<IWeaponItemInput>();
        builder.RegisterComponentInHierarchy<PlayerWeaponHandler>();

        builder.RegisterBuildCallback(container =>
        {
            container.InjectGameObject(_weaponSetupsParent);
        });
    }
}
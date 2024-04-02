using Modules.Items.ItemPickSystem;
using Modules.Items.Weapons.Ammunition;
using Modules.Items.Weapons.InputSystem;
using Modules.Items.Weapons.Range;
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

        builder.RegisterBuildCallback(container =>
        {
            container.InjectGameObject(_weaponSetupsParent);
        });
    }
}
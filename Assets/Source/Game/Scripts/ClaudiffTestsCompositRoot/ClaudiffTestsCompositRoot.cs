using Modules.CoroutineStarterSystem;
using Modules.Items.ItemPickSystem;
using Modules.Items.Weapons;
using Modules.Items.Weapons.Ammunition;
using Modules.Items.Weapons.InputSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ClaudiffTestsCompositRoot : LifetimeScope
{
    [SerializeField] private WeaponConfigFabric _weaponConfigFabric;
    [SerializeField] private GameObject _weaponSetupsParent;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<CoroutineStarter>();
        builder.RegisterComponentInHierarchy<IPickable>();
        builder.RegisterComponentInHierarchy<IItemSelectionInput>();

        builder.RegisterInstance(_weaponConfigFabric);
        builder.RegisterComponentInHierarchy<WeaponAmmunitionView>();
        builder.RegisterEntryPoint<ShotDesktopInput>().As(typeof(IShotInput));

        builder.RegisterBuildCallback(container =>
        {
            container.InjectGameObject(_weaponSetupsParent);
        });
    }
}
using Modules.CoroutineStarterSystem;
using Modules.Items.ItemPickSystem;
using Modules.Items.Weapons;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ClaudiffTestsCompositRoot : LifetimeScope
{
    [SerializeField] private WeaponConfigFabric _weaponConfigFabric;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<CoroutineStarter>();
        builder.RegisterComponentInHierarchy<IPickable>();
        builder.RegisterComponentInHierarchy<IItemSelectionInput>();

        builder.RegisterInstance(_weaponConfigFabric);
        builder.RegisterEntryPoint<ShotDesktopInput>().As(typeof(ShotDesktopInput));
        builder.Register<Weapon>(Lifetime.Singleton);
        builder.RegisterBuildCallback(container => container.Resolve<Weapon>());
    }
}

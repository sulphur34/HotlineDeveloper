using Modules.Items.ItemPickSystem;
using Modules.Items.Weapons;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ClaudiffTestsCompositRoot : LifetimeScope
{
    [SerializeField] private BulletConfigFabric _bulletConfigFabric;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<IPickable>();
        builder.RegisterComponentInHierarchy<IItemSelectionInput>();

        builder.RegisterInstance(_bulletConfigFabric);
        builder.RegisterEntryPoint<ShotDesktopInput>().As(typeof(ShotDesktopInput));
        builder.Register<Weapon>(Lifetime.Singleton);
        builder.RegisterBuildCallback(container => container.Resolve<Weapon>());
    }
}

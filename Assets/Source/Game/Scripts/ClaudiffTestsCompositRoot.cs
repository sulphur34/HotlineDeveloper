using Modules.Items.ItemPickSystem;
using VContainer;
using VContainer.Unity;

public class ClaudiffTestsCompositRoot : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<IPickable>();
        builder.RegisterComponentInHierarchy<IItemSelectionInput>();
    }
}

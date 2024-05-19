using LevelSelectionSystem;
using Modules.FadeSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MenuCompositionRoot : LifetimeScope
{
    [SerializeField] private LevelSelectionElement[] _levelSelectionElements;
    [SerializeField] private PressedButton _levelSelectionButton;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_levelSelectionElements);
        builder.RegisterInstance(_levelSelectionButton);
        builder.RegisterComponentInHierarchy<LevelSelectionSetup>();
        builder.RegisterComponentInHierarchy<Fade>();
        builder.Register<LevelSceneLoader>(Lifetime.Singleton);

        builder.RegisterBuildCallback(container =>
        {
            container.Resolve<LevelSceneLoader>();
        });
    }
}
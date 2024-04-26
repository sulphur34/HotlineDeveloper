using Modules.FadeSystem;
using Modules.LevelSelectionSystem;
using Modules.LevelsSystem;
using Modules.PressedButtonSystem;
using Modules.SavingsSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MenuCompositRoot : LifetimeScope
{
    private readonly SaveSystem _saveSystem = new SaveSystem();

    [SerializeField] private LevelSelectionElement[] _levelSelectionElements;
    [SerializeField] private PressedButton _levelSelectionButton;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_levelSelectionElements);
        builder.RegisterInstance(_levelSelectionButton);
        builder.RegisterComponentInHierarchy<LevelSelectionSetup>();
        builder.RegisterComponentInHierarchy<Fade>();
        builder.Register<LevelSceneLoader>(Lifetime.Singleton);

        _saveSystem.Load(data =>
        {
            Level currentLevel = new Level(data.CurrentLevel);
            builder.RegisterInstance(currentLevel);
        });

        builder.RegisterBuildCallback(container =>
        {
            container.Resolve<LevelSceneLoader>();
        });
    }
}
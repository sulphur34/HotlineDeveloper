using Modules.FadeSystem;
using Modules.LevelSelectionSystem;
using Modules.LevelsSystem;
using Modules.PressedButtonSystem;
using Modules.SaveHandlers;
using System.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MenuCompositRoot : LifetimeScope
{
    [SerializeField] private LevelSelectionElement[] _levelSelectionElements;
    [SerializeField] private PressedButton _levelSelectionButton;

    protected override void OnDestroy()
    {
        Dispose();
    }

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_levelSelectionElements);
        builder.RegisterInstance(_levelSelectionButton);
        builder.Register<LevelSceneLoader>(Lifetime.Singleton);
        builder.Register<LevelSelectionPresenter>(Lifetime.Singleton);
        builder.Register<SelectedLevelSaveHandler>(Lifetime.Singleton);

        builder.RegisterBuildCallback(container =>
        {
            Level lastLoadedLevel = container.Resolve<Level>();
            LevelSelectionElement levelSelectionElement = _levelSelectionElements.FirstOrDefault(element => element.LevelNumberForLoad == lastLoadedLevel.Number);
            levelSelectionElement.Select();
            container.Resolve<LevelSelectionPresenter>();
            container.Resolve<SelectedLevelSaveHandler>();
            container.Resolve<Fade>().Out();
        });
    }
}
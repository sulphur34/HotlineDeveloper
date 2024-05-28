using Module.ContinueLevelButtonSystem;
using Modules.FadeSystem;
using Modules.LevelSelectionSystem;
using Modules.LevelsSystem;
using Modules.PressedButtonSystem;
using Modules.SaveHandlers;
using Modules.SavingsSystem;
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

        builder.RegisterComponentInHierarchy<ContinueLevelButton>();
        builder.RegisterComponentInHierarchy<ContinueLevelButtonView>();
        builder.Register<ContinueLevelButtonPresenter>(Lifetime.Singleton);

        builder.RegisterBuildCallback(container =>
        {
            int levelForLoad = container.Resolve<LevelsData>().ForLoad;

            LevelSelectionElement levelSelectionElement = _levelSelectionElements.FirstOrDefault(element => element.LevelNumberForLoad == levelForLoad);
            levelSelectionElement.Select();
            container.Resolve<LevelSelectionPresenter>();
            container.Resolve<SelectedLevelSaveHandler>();
            container.Resolve<ContinueLevelButtonPresenter>();
            container.Resolve<Fade>().Out();
        });
    }
}
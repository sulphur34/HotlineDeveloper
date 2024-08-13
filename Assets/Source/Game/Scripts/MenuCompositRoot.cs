using Module.ContinueLevelButtonSystem;
using Modules.FadeSystem;
using Modules.LeaderboardSystem;
using Modules.LevelSelectionSystem;
using Modules.LevelsSystem;
using Modules.PressedButtonSystem;
using Modules.SaveHandlers;
using Modules.SavingsSystem;
using System.Collections;
using System.Linq;
using Modules.Audio;
using Source.Modules.AudioInitializationSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using AudioSettings = Modules.Audio.AudioSettings;

public class MenuCompositRoot : LifetimeScope
{
    [SerializeField] private LevelSelectionElement[] _levelSelectionElements;
    [SerializeField] private PressedButton _levelSelectionButton;

    private readonly SaveSystem _saveSystem = new SaveSystem();

    protected override void OnDestroy()
    {
        Dispose();
    }

    protected override void Configure(IContainerBuilder builder)
    {
        LevelSelectionConfigure(builder);
        LeaderboardConfigure(builder);
        ContinueLevelConfigure(builder);
        AudioConfigure(builder);
        ResolveDependencies(builder);
    }

    private void LevelSelectionConfigure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_levelSelectionElements);
        builder.RegisterInstance(_levelSelectionButton);
        builder.Register<LevelSceneLoader>(Lifetime.Singleton);
        builder.Register<LevelSelectionPresenter>(Lifetime.Singleton);
        builder.Register<SelectedLevelSaveHandler>(Lifetime.Singleton);
    }

    private void LeaderboardConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<LeaderboardView>();
        builder.RegisterComponentInHierarchy<AuthorizationButton>();
        builder.RegisterComponentInHierarchy<LeaderboardOpenButton>();
        builder.Register<LeaderboardPresenter>(Lifetime.Singleton);
    }

    private void ContinueLevelConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<ContinueLevelButton>();
        builder.RegisterComponentInHierarchy<ContinueLevelButtonView>();
        builder.Register<ContinueLevelButtonPresenter>(Lifetime.Singleton);
    }

    private void AudioConfigure(IContainerBuilder builder)
    {
        builder.Register<SaveSystem>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<AudioSettings>();
        builder.Register<AudioInitializer>(Lifetime.Singleton);
        builder.Register<AudioSaveHandler>(Lifetime.Singleton);
    }

    private void ResolveDependencies(IContainerBuilder builder)
    {
        builder.RegisterBuildCallback(container =>
        {
            LevelsData levelsData = container.Resolve<LevelsData>();
            int levelForLoad = levelsData.ForLoad;

            LevelSelectionElement levelSelectionElement =
                _levelSelectionElements.FirstOrDefault(element => element.LevelNumberForLoad == levelForLoad);
            levelSelectionElement.Select();

            for (int i = 0; i < _levelSelectionElements.Length; i++)
                _levelSelectionElements[i].SetScore(levelsData.Value[i].Score);

            container.Resolve<LevelSelectionPresenter>();
            container.Resolve<SelectedLevelSaveHandler>();
            container.Resolve<ContinueLevelButtonPresenter>();
            container.Resolve<LeaderboardPresenter>();
            container.Resolve<AudioSettings>();
            container.Resolve<AudioInitializer>().Initialize();
            container.Resolve<AudioSaveHandler>();
            container.Resolve<Fade>().Out();
        });
    }
}
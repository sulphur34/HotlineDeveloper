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
        builder.RegisterInstance(_levelSelectionElements);
        builder.RegisterInstance(_levelSelectionButton);
        builder.Register<LevelSceneLoader>(Lifetime.Singleton);
        builder.Register<LevelSelectionPresenter>(Lifetime.Singleton);
        builder.Register<SelectedLevelSaveHandler>(Lifetime.Singleton);
        builder.Register<AudioSaveHandler>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<LeaderboardView>();
        builder.RegisterComponentInHierarchy<AuthorizationButton>();
        builder.RegisterComponentInHierarchy<LeaderboardOpenButton>();
        builder.Register<LeaderboardPresenter>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<AudioSettings>();
        builder.RegisterComponentInHierarchy<ContinueLevelButton>();
        builder.RegisterComponentInHierarchy<ContinueLevelButtonView>();
        builder.Register<ContinueLevelButtonPresenter>(Lifetime.Singleton);

        builder.RegisterBuildCallback(container =>
        {
            LevelsData levelsData = container.Resolve<LevelsData>();
            int levelForLoad = levelsData.ForLoad;

            LevelSelectionElement levelSelectionElement =
                _levelSelectionElements.FirstOrDefault(element => element.LevelNumberForLoad == levelForLoad);
            levelSelectionElement.Select();

            for (int i = 0; i < _levelSelectionElements.Length; i++)
                _levelSelectionElements[i].SetScore(levelsData.Value[i].Score);

            AudioSettings audioSettings = container.Resolve<AudioSettings>();
            StartCoroutine(InitAudioSettings(audioSettings));

            container.Resolve<LevelSelectionPresenter>();
            container.Resolve<SelectedLevelSaveHandler>();
            container.Resolve<AudioSaveHandler>();
            container.Resolve<ContinueLevelButtonPresenter>();
            container.Resolve<LeaderboardPresenter>();
            container.Resolve<Fade>().Out();
        });
    }

    private IEnumerator InitAudioSettings(AudioSettings audioSettings)
    {
        yield return null;

        _saveSystem.Load(data =>
        {
            audioSettings.MusicSlider.Init(data.AudioSettingsData.MusicVolume);
            audioSettings.SoundSlider.Init(data.AudioSettingsData.SoundVolume);
        });
    }
}
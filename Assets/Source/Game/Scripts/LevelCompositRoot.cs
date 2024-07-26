using Module.ContinueLevelButtonSystem;
using Modules.Audio;
using Modules.FadeSystem;
using Modules.LevelsSystem;
using Modules.PauseMenu;
using Modules.PlayerWeaponsHandler;
using Modules.SaveHandlers;
using Modules.Weapons.Ammunition;
using Modules.Weapons.Range;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Modules.MoveSystem;
using Modules.CharacterSystem.Player;
using Modules.EnemySpawnSystem;
using Modules.CharacterSystem.EnemySystem.EnemyBehavior;
using Modules.DamageSystem;
using Modules.LevelSelectionSystem;
using Modules.ScoreSystem;
using Agava.YandexGames;
using Modules.LeaderboardSystem;
using Source.Modules.NextLevelButtonSystem;

public class LevelCompositRoot : LifetimeScope
{
    [SerializeField] private MoverConfig _moverConfig;
    [SerializeField] private RangeWeaponConfigFactory _weaponConfigFactory;
    [SerializeField] private WeaponTracker _weaponTracker;
    [SerializeField] private LevelEnemySpawnConfigs _enemySpawnConfigs;
    [SerializeField] private BehaviorConfigFactory _desktopBehaviorConfigFactory;
    [SerializeField] private BehaviorConfigFactory _mobileBehaviorConfigFactory;
    [SerializeField] private DamageableConfigFactory _damageableConfigFactory;
    [SerializeField] private GameObject _weaponSetupsParent;
    [SerializeField] private Player _player;

    private RegistrationBuilder _playerRegistration;

    protected override void OnDestroy()
    {
        Dispose();
    }

    protected override void Configure(IContainerBuilder builder)
    {
        InputConfigure(builder);
        MoverConfigure(builder);
        DamageConfigure(builder);
        WeaponConfigure(builder);
        EnemyConfigure(builder);
        LevelConfigure(builder);
        UIConfigure(builder);
    }

    private void EnemyConfigure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_enemySpawnConfigs);

        if (Application.isMobilePlatform)
            builder.RegisterInstance(_mobileBehaviorConfigFactory);
        else
            builder.RegisterInstance(_desktopBehaviorConfigFactory);

        builder.RegisterComponentInHierarchy<EnemySpawner>();
    }

    private void MoverConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<MoverSetup>();
        builder.RegisterInstance(_moverConfig);
    }

    private void InputConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<MobileInputUI>();
        builder.RegisterInstance(_player);
        InputController inputController;

        if (Application.isMobilePlatform)
        {
            inputController = _player.gameObject.AddComponent<MobileInputController>();
            builder.RegisterBuildCallback(container =>
            {
                container.Resolve<MobileInputUI>().gameObject.SetActive(true);
            });
        }
        else
        {
            inputController = _player.gameObject.AddComponent<DesktopInputController>();
        }

        builder.RegisterInstance(inputController).AsImplementedInterfaces();
    }

    private void DamageConfigure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_damageableConfigFactory);
        builder.RegisterComponentInHierarchy<DamageReceiverSetup>();
        builder.RegisterComponentInHierarchy<WeaponStrategy>();
        DamageableConfig damageableConfig = _damageableConfigFactory.GetConfig(DamageableTypes.Immortal);
        _player.GetComponent<DamageReceiverSetup>().Initialize(damageableConfig);
    }

    private void WeaponConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<WeaponTracker>();
        builder.RegisterInstance(_weaponConfigFactory);
        builder.RegisterComponentInHierarchy<WeaponAmmunitionView>();
        builder.RegisterComponentInHierarchy<PlayerWeaponHandlerSetup>();
        builder.RegisterBuildCallback(container => { container.Resolve<WeaponTracker>().Construct(); });
        builder.RegisterBuildCallback(container => { container.InjectGameObject(_weaponTracker.gameObject); });
    }

    private void LevelConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<EndLevelTrigger>();
        builder.RegisterComponentInHierarchy<EnemyTracker>();
        builder.Register<ScoreCounter>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<LevelConditionManager>();
        builder.RegisterComponentInHierarchy<ScoreCounterView>();
        builder.RegisterComponentInHierarchy<LevelConditionManager>();
        builder.Register<LevelSaveHandler>(Lifetime.Singleton);
        builder.Register<ScoreSaveHandler>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<CameraFollower>();
        builder.Register<PauseSetter>(Lifetime.Singleton);
        builder.Register<LevelSceneLoader>(Lifetime.Singleton);
        builder.Register<LeaderboardUpdater>(Lifetime.Singleton);

        builder.RegisterBuildCallback(container =>
        {
            container.Resolve<EnemySpawner>().BuildEnemies();
            container.Resolve<EnemyTracker>().Activate();
            container.InjectGameObject(_weaponSetupsParent);
            container.Resolve<LevelSaveHandler>();
            container.Resolve<ScoreSaveHandler>();
            container.Resolve<LeaderboardUpdater>();
            container.Resolve<Fade>().Out();
        });
    }

    private void UIConfigure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<PauseSetButton>();
        builder.RegisterComponentInHierarchy<LoadSceneButton>();
        builder.RegisterComponentInHierarchy<RestartLevelButton>();
        builder.RegisterComponentInHierarchy<UIDirectionPointer>();
        builder.RegisterComponentInHierarchy<UIAimFollower>();
        builder.RegisterComponentInHierarchy<UIConditionListener>();
        builder.RegisterComponentInHierarchy<NextLevelButton>();
        builder.RegisterComponentInHierarchy<NextLevelButtonView>();
        builder.Register<NextLevelButtonPresenter>(Lifetime.Singleton);
        
        builder.RegisterBuildCallback(container =>
        {
            container.Resolve<NextLevelButtonPresenter>();
        });
    }
}